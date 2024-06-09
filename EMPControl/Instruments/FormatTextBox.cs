using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EMPControl.Instruments
{
    public class FormatTextBox : TextBox
    {
        public FormatTextBox()
        {
            DataObject.AddPastingHandler(this, Pasting);
        }
    
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            if (IsValidInput(GetText(e.Text))) return;
            SystemSounds.Beep.Play();
            e.Handled = true;
        }
    
        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));
                if (IsValidInput(GetText(pastedText))) return;
            }
            SystemSounds.Beep.Play();
            e.CancelCommand();
        }
    
        private string GetText(string input)
        {
            int selectionStart = SelectionStart;
            if (Text.Length < selectionStart)
                selectionStart = Text.Length;
            int selectionLength = SelectionLength;
            if (Text.Length < selectionStart + selectionLength)
                selectionLength = Text.Length - selectionStart;
            var realtext = Text.Remove(selectionStart, selectionLength);
            int caretIndex = CaretIndex;
            if (realtext.Length < caretIndex)
                caretIndex = realtext.Length;
            var newtext = realtext.Insert(caretIndex, input);
            return newtext;
        }
        
        //Разрешенные символы

        private bool IsValidInput(string input)
        {
            return input.All(c => ("0123456789" +
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "abcdefghijklmnopqrstuvwxyz" +
            "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" +
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" +
            ".,-/").Contains(c));
        }
    }
}


