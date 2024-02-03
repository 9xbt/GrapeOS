using GrapeOS.Graphics.Controls;
using GrapeGL.Graphics;

namespace GrapeOS.Graphics
{
    internal class Dialogue : Window 
    {
        internal string Message;

        internal Dialogue(string Title, string Message) : base(
            (WindowManager.Screen.Width / 2) - ((96 + Resources.Charcoal.MeasureString(Message)) / 2), 
            (WindowManager.Screen.Height / 2) - (100 / 2), (ushort)(96 + Resources.Charcoal.MeasureString(Message)), 100, Title)
        {
            this.Message = Message;

            _ = new ImageView(this, 20, 10, Resources.TalkingMan);
            _ = new Label(this, 76, 10, Message, Resources.Charcoal, Color.Black);
            _ = new Button(this, Width - 69, Height - 30, 59, 20, "OK") { Clicked = Dispose };
        }
    }
}
