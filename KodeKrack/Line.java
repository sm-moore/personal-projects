import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import javax.swing.JComponent;

/**
 * Create a Line Component which can be drawn on a JComponent. This line is a bit thicker than other lines.
 * 
 * @author Sara Adamson
 */
public class Line extends JComponent
{
    /**
     * psh, who knows what this does?
     */
    private static final long serialVersionUID = -1040716241810324698L;
    private Point from, to;

    /**
     * Constructs a line from the given from point to the given to point in the given color. 
     * @param from starting point of this line.
     * @param to ending point of this line. 
     * @param color color of this line. 
     */
    public Line (Point from, Point to, Color color)
    {
        this.setSize(1000, 1000);
        this.setName("line");
        this.setForeground(color);
        this.from = from;
        this.to = to;
    }

    @Override
    public void paintComponent (Graphics g)
    {
        super.paintComponent(g);
        Graphics2D g2d = (Graphics2D) g.create();
        g2d.setStroke(new BasicStroke(5));
        g2d.drawLine(from.x, from.y, to.x, to.y);
        g2d.dispose();
    }
}
