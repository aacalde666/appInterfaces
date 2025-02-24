using System;
using System.Windows.Forms;

namespace ventana
{
    public partial class InputBoxForm : Form
    {
        private TextBox inputTextBox;
        private Button okButton;
        private Button cancelButton;
        public string InputText { get; private set; }

        public InputBoxForm(string title, string prompt)
        {
            InitializeComponent();
            Text = title;

            Label promptLabel = new Label { Text = prompt, Dock = DockStyle.Top, Padding = new Padding(10) };
            inputTextBox = new TextBox { Dock = DockStyle.Top, Padding = new Padding(10) };
            inputTextBox.PasswordChar = '*';
            okButton = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Left };
            cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Dock = DockStyle.Right };

            FlowLayoutPanel buttonsPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, FlowDirection = FlowDirection.RightToLeft };
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(okButton);

            Controls.Add(promptLabel);
            Controls.Add(inputTextBox);
            Controls.Add(buttonsPanel);

            AcceptButton = okButton;
            CancelButton = cancelButton;

            okButton.Click += (s, e) => InputText = inputTextBox.Text;
        }

        public static string Show(string title, string prompt)
        {
            using (var form = new InputBoxForm(title, prompt))
            {
                return form.ShowDialog() == DialogResult.OK ? form.InputText : null;
            }
        }
    }
}
