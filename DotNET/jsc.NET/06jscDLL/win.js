import System.Windows.Forms; // this has a MessageBox class
import LibHello;

var h = new LibHello.Hello();
MessageBox.Show(
        h.say(),
        "Dude!",
        MessageBoxButtons.OK,
        MessageBoxIcon.Exclamation
);