using System;
using System.Reflection;
using System.Windows.Forms;

namespace Kursik
{
    /// <summary>
    /// Форма "О программе" — простое информационное окно с информацией и ссылкой на автора.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Создаёт экземпляр AboutForm, инициализирует компоненты формы и загружает версию приложения.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Обработчик нажатия кнопки "OK" — закрывает окно AboutForm.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик клика по ссылке автора: пытается открыть указанный URL в браузере по умолчанию.
        /// Ошибки открытия подавляются, чтобы не мешать работе приложения.
        /// </summary>
        /// <param name="sender">Источник события (LinkLabel).</param>
        /// <param name="e">Аргументы события LinkLabelLinkClickedEventArgs.</param>
        private void lnkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://example.com",
                    UseShellExecute = true
                });
            }
            catch
            {
                // ignore
            }
        }
    }
}
