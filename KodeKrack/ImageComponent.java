import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.io.IOException;
import java.net.URL;
import javax.imageio.ImageIO;
import javax.swing.JComponent;

class ImageComponent extends JComponent
{
    /**
     * What is this???
     */
    private static final long serialVersionUID = 1L;
    private Image img;

    /**
     * Constructs an Image which can be painted onto a panel. The image must be included in a jar file in referenced
     * libraries.
     * 
     * @param _img image to be constructed. 
     */
    public ImageComponent (String _img)
    {
        URL url = ImageComponent.class.getResource(_img);
        try
        {
            img = ImageIO.read(url);
            Dimension size = new Dimension(img.getWidth(null), img.getHeight(null));
            setPreferredSize(size);
            setMinimumSize(size);
            setMaximumSize(size);
            setSize(size);
            setLayout(null);
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    public void paintComponent (Graphics g)
    {
        g.drawImage(img, 0, 0, null);
    }
}