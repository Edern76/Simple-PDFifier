using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace CustomExcept
{


    public class DefaultPathException : Exception
    {
        DateTime m_errorTime;

        public DefaultPathException()
            : base("You must specify a path !")
        {
            m_errorTime = DateTime.Now;
        }

        public DefaultPathException(string message)
            : base(message)
        {
            m_errorTime = DateTime.Now;
        }

        public void DisplayError()
        {
            System.Windows.Forms.MessageBox.Show(
                base.Message,
                string.Format(
                    "Error occured at {0}.",
                    m_errorTime.ToLongTimeString()),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    public class InputFileNonExistent : Exception
    {
        DateTime m_errorTime;

        public InputFileNonExistent()
            : base("Cannot find input file !")
        {
            m_errorTime = DateTime.Now;
        }

        public InputFileNonExistent(string message)
            : base(message)
        {
            m_errorTime = DateTime.Now;
        }

        public void DisplayError()
        {
            System.Windows.Forms.MessageBox.Show(
                base.Message,
                string.Format(
                    "Error occured at {0}.",
                    m_errorTime.ToLongTimeString()),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    public class WrongPathException : Exception
    {
        DateTime m_errorTime;

        public WrongPathException()
            : base("Specified path is incorrect !")
        {
            m_errorTime = DateTime.Now;
        }

        public WrongPathException(string message)
            : base(message)
        {
            m_errorTime = DateTime.Now;
        }

        public void DisplayError()
        {
            System.Windows.Forms.MessageBox.Show(
                base.Message,
                string.Format(
                    "Error occured at {0}.",
                    m_errorTime.ToLongTimeString()),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    public class WrongFormatException : Exception
    {
        DateTime m_errorTime;

        public WrongFormatException()
            : base("Specified format is incorrect !")
        {
            m_errorTime = DateTime.Now;
        }

        public WrongFormatException(string message)
            : base(message)
        {
            m_errorTime = DateTime.Now;
        }

        public void DisplayError()
        {
            System.Windows.Forms.MessageBox.Show(
                base.Message,
                string.Format(
                    "Error occured at {0}.",
                    m_errorTime.ToLongTimeString()),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
