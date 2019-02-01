import java.awt.Color;
import java.awt.Point;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Scanner;
import javax.swing.JPanel;
import javax.swing.JTextField;

/**
 * Create the Model for KodeKrack.
 * 
 * @author Sara Adamson
 */
public class KodeKrackProgram
{
    private Point from_us, from_them, fireWall_1_us, fireWall_2_us, fireWall_3_us, fireWall_1_them, fireWall_2_them,
            fireWall_3_them;

    private HashSet<String> possiblePasswords_station1, possiblePasswords_station2, possiblePasswords_station3;

    private Color GOOD_COLOR = Color.GREEN;
    private Color BAD_COLOR = Color.RED;

    public KodeKrackProgram (JTextField text, JPanel mainPanel, Point from_us, Point from_them, Point fireWall_1_us,
            Point fireWall_1_them, Point fireWall_2_us, Point fireWall_2_them, Point fireWall_3_us,
            Point fireWall_3_them)
    {
        this.from_us = from_us;
        this.from_them = from_them;
        this.fireWall_1_us = fireWall_1_us;
        this.fireWall_2_us = fireWall_2_us;
        this.fireWall_3_us = fireWall_3_us;
        this.fireWall_1_them = fireWall_1_them;
        this.fireWall_2_them = fireWall_2_them;
        this.fireWall_3_them = fireWall_3_them;
        
        // Create a list of the possible passwords.
        possiblePasswords_station1 = new HashSet<>();
        possiblePasswords_station2 = new HashSet<>();
        possiblePasswords_station3 = new HashSet<>();
        populatePasswords("/Resources/passwords.txt");
    }

    /**
     * Determines if the password is correct and if it is, draws lines on the screen accordingly.
     * 
     * @param mainPanel Panel to draw on.
     * @param password Password to validate. 
     * @return the number of correct passwords.
     */
    public int validatePassword (JPanel mainPanel, String password, int count_correct)
    {
        // draw a line from us to them.
        switch (password.charAt(0)) // first character is station number.
        {
            case '1':
                mainPanel.add(new Line(from_us, fireWall_1_us, GOOD_COLOR));

                if (possiblePasswords_station1.contains(password))
                {
                    mainPanel.add(new Line(from_them, fireWall_1_them, GOOD_COLOR));
                    count_correct++;
                }
                else
                {
                    mainPanel.add(new Line(from_them, fireWall_1_them, BAD_COLOR));
                }
                break;
            case '2':
                mainPanel.add(new Line(from_us, fireWall_2_us, GOOD_COLOR));

                if (possiblePasswords_station2.contains(password))
                {
                    mainPanel.add(new Line(from_them, fireWall_2_them, GOOD_COLOR));
                    count_correct++;
                }
                else
                {
                    mainPanel.add(new Line(from_them, fireWall_2_them, BAD_COLOR));
                }
                break;
            case '3':
                mainPanel.add(new Line(from_us, fireWall_3_us, GOOD_COLOR));
                if (possiblePasswords_station3.contains(password))
                {
                    mainPanel.add(new Line(from_them, fireWall_3_them, GOOD_COLOR));
                    count_correct++;
                }
                else
                {
                    mainPanel.add(new Line(from_them, fireWall_3_them, BAD_COLOR));
                }
                break;
        }
        mainPanel.repaint();

        return count_correct;
    }

    /**
     * Determines if the password is correct and if it is, draws lines on the screen accordingly
     * 
     * @param mainPanel
     * @param password
     * @return the number of correct passwords.
     */
    private boolean validate_password (String password)
    {
        // draw a line from us to them.
        switch (password.charAt(0)) // first character is station number.
        {
            case '1':
                if (possiblePasswords_station1.contains(password))
                {
                    return true;
                }
                break;
            case '2':
                if (possiblePasswords_station2.contains(password))
                {
                    return true;
                }
                break;
            case '3':
                if (possiblePasswords_station3.contains(password))
                {
                    return true;
                }
                break;
        }

        return false;
    }

    /** 
     * Slowly draws a line from point from to point to on the given JPanel 
     * I couldn't get this to work... how sad.
     */
    private void drawSlowly (Point from, Point to, JPanel main)
    {
        long timeBetween = 100_000_000; // wait a bit
        long startTime;
        Line l;

        // change values in l, and add them to main, and repaint incrementally.
        Point tempTo;

        // To find the points on the line I need to use point slope formula.
        Double slope = (to.getY() - from.getY()) / (to.getX() - from.getX()); // The slope between these two lines.

        // I will use incremental values of y (top down) and compute the values of x.
        Double tempY = from.getY(); // top y value.

        // find the x value associated with this y value using point slope.
        Double tempX;

        int it = 0;
        while (it < 11) // stop when we've added the entire line.
        {
            tempX = (tempY - from.y + slope * from.x) / slope;

            tempTo = new Point((int) (1 * tempX), (int) (1 * tempY));
            l = new Line(from, tempTo, GOOD_COLOR);

            main.add(l);
            main.repaint();
            
            tempY++;

            if (tempTo.y > to.y)
            {
                break;
            }

            startTime = System.nanoTime();
            while (System.nanoTime() - startTime < timeBetween)
            {
                // the waiting game... joy.
            }
            it++;
        }
    }

    /**
     * Populates the passwords set using the given filename.
     */
    private void populatePasswords (String fileName)
    {
        try
        {
            // Use the file from a .jar and process it.
            InputStream in = getClass().getResourceAsStream(fileName);
            BufferedReader reader = new BufferedReader(new InputStreamReader(in));
            Scanner s = new Scanner(reader);

            while (s.hasNextLine())
            {
                String str = s.nextLine();
                if (str.isEmpty()) // part of next set
                {
                    break;
                }
                // add each line to the possiblePasswords.
                possiblePasswords_station1.add(str.trim());
            }

            while (s.hasNextLine())
            {
                String str = s.nextLine();
                if (str.isEmpty()) // part of next set
                {
                    break;
                }
                // add each line to the possiblePasswords.
                possiblePasswords_station2.add(str.trim());
            }

            while (s.hasNextLine())
            {
                String str = s.nextLine();
                if (str.isEmpty()) // part of next set
                {
                    break;
                }
                // add each line to the possiblePasswords.
                possiblePasswords_station3.add(str.trim());
            }
            s.close();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}