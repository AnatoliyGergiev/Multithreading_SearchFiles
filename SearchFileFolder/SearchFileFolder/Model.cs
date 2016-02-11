using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SearchFileFolder
{
    class Model
    {
        public List<FileInfo> files;
        public string File { get; set; }
        public string Phrase { get; set; }
        public string Disk { get; set; }
        public bool Subdirectory { get; set; }
        public event EventHandler<EventArgs> SearchFinished;
        public event EventHandler<List<FileInfo>> Found_event;
        public volatile bool stop_search = false;
        public delegate void MyDelegate();
        MyDelegate md;
        IAsyncResult ar;
        public Model()
        {
            files = new List<FileInfo>();
        }
        public void Search()
        {
            md = SearchMethod;
            ar = md.BeginInvoke(null,null);
            //while (true)
            //{
            //    if (ar.IsCompleted)
            //    {
            //        md.EndInvoke(ar);
            //    }
            //}
            //Thread trd = new Thread(() => SearchMethod());
            //trd.Start();
        }
        private void SearchMethod()
        {
            if (files.Count != 0)
                files.Clear();
            DirectoryInfo di = new DirectoryInfo(Disk);
            if (!di.Exists)
            {
                return;
            }
            string Mask = File;
            Mask = Mask.Replace(".", @"\.");
            Mask = Mask.Replace("?", ".");
            Mask = Mask.Replace("*", ".*");
            // Указываем, что требуется найти точное соответствие маске
            Mask = "^" + Mask + "$";

            Regex regMask = new Regex(Mask, RegexOptions.IgnoreCase);

            if (Phrase != "")
            {
                // Экранируем спецсимволы во введенном тексте
                string Text = Phrase;
                Text = Regex.Escape(Text);
                // Создание объекта регулярного выражения
                // на основе текста
                Regex regText = Text.Length == 0 ? null : new Regex(Text, RegexOptions.IgnoreCase);

                try
                {
                    // Вызываем функцию поиска
                    ulong Count = FindTextInFiles(regText, di, regMask);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                FindFiles(di, regMask);
            SearchFinished(this,null);
            md.EndInvoke(ar);
        }
        private ulong FindFiles(DirectoryInfo di, Regex regMask)
        {
            List<FileInfo> retfiles = new List<FileInfo>();
            // Количество обработанных файлов
            ulong CountOfMatchFiles = 0;
            if (stop_search)
                return CountOfMatchFiles;

            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatchFiles;
            }

            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name))
                {
                    // Увеличиваем счетчик
                    ++CountOfMatchFiles;
                    files.Add(f);
                    retfiles.Add(f);
                }
            }
            if (Subdirectory)
            {
                // Получаем список подкаталогов
                DirectoryInfo[] diSub = di.GetDirectories();
                // Для каждого из них вызываем (рекурсивно)
                // эту же функцию поиска
                foreach (DirectoryInfo diSubDir in diSub)
                    CountOfMatchFiles += FindFiles(diSubDir, regMask);

                // Возврат количества обработанных файлов
            }
            Found_event(this, retfiles);
            return CountOfMatchFiles;
        }
        private ulong FindTextInFiles(Regex regText, DirectoryInfo di, Regex regMask)
        {
            List<FileInfo> retfiles = new List<FileInfo>(); 
            // Поток для чтения из файла
            StreamReader sr = null;
            // Список найденных совпадений
            MatchCollection mc = null;

            // Количество обработанных файлов
            ulong CountOfMatchFiles = 0;

            if (stop_search)
                return CountOfMatchFiles;

            FileInfo[] fi = null;
            try
            {
                // Получаем список файлов
                fi = di.GetFiles();
            }
            catch
            {
                return CountOfMatchFiles;
            }

            // Перебираем список файлов
            foreach (FileInfo f in fi)
            {
                // Если файл соответствует маске
                if (regMask.IsMatch(f.Name))
                {
                    if (regText != null)
                    {
                        // Открываем файл
                        sr = new StreamReader(di.FullName + @"\" + f.Name,
                            Encoding.Default);
                        // Считываем целиком
                        string Content = sr.ReadToEnd();
                        // Закрываем файл
                        sr.Close();
                        // Ищем заданный текст
                        mc = regText.Matches(Content);
                        if (mc.Count != 0)
                        {
                            ++CountOfMatchFiles;
                            files.Add(f);
                            retfiles.Add(f);
                        }
                    }
                }
            }
            if (Subdirectory)
            {
                // Получаем список подкаталогов
                DirectoryInfo[] diSub = di.GetDirectories();
                // Для каждого из них вызываем (рекурсивно)
                // эту же функцию поиска
                foreach (DirectoryInfo diSubDir in diSub)
                    CountOfMatchFiles += FindTextInFiles(regText, diSubDir, regMask);
            }
            // Возврат количества обработанных файлов
            Found_event(this, retfiles);
            return CountOfMatchFiles;
        }
    }
}
