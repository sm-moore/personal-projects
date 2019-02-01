import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedInputStream;
import java.io.InputStream;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.swing.*;

/**
 * Create a KodeKrack program/game to be played at SWE GSN. I'm so excited!!!!
 * 
 * @author Sara Adamson
 */
public class HackerDisplay
{
    /************************ Some Useful Constants ***********************/
    static Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
    final static int SCREEN_WIDTH = screenSize.width;
    final static int SCREEN_HEIGHT = screenSize.height;

    /***************** Shared Fields *************************************/
    final static Font TEXT_FONT = new Font("Serif", Font.PLAIN, 24);
    final static Font TITLE_TEXT_FONT = new Font("Serif", Font.PLAIN, 60);
    final static Color BACKGROUND_COLOR = Color.BLACK;
    final static Color GOOD_COLOR = Color.GREEN;
    final static Color BAD_COLOR = Color.RED;
    final static Point TOGGLE_PROGRAM_BUTTON_LOCATION = new Point(10, 10);
    final static Point TITLE_LABEL_LOCATION_START_POINT = new Point(SCREEN_WIDTH / 2, 10);

    /***************** Decryption fields ****************************/
    final static Point PASSWORD_LABEL_LOCATION = new Point((SCREEN_WIDTH / 2) - (SCREEN_WIDTH / 4),
            7 * (SCREEN_HEIGHT / 13));
    final static Point DECRYPT_BUTTON_LOCATION = new Point(7 * (SCREEN_WIDTH / 11), 7 * (SCREEN_HEIGHT / 13));
    final static Point textAreaLocation = new Point(3 * (SCREEN_WIDTH / 8), 7 * (SCREEN_HEIGHT / 13));
    final static Point decryptTextAreaLocation = new Point(3 * (SCREEN_WIDTH / 8), 7 * (SCREEN_HEIGHT / 13) + 30);

    /***************** Hacker fields *************************************/
    final static Point KK_PASSWORD_LABEL_LOCATION = new Point((SCREEN_WIDTH / 2) - (SCREEN_WIDTH / 4),
            14 * (SCREEN_HEIGHT / 17));
    final static Point HACK_BUTTON_LOCATION = new Point(7 * (SCREEN_WIDTH / 11), 14 * (SCREEN_HEIGHT / 17) - 2);
    final static Point RESULTS_BUTTON_LOCATION = new Point(7 * SCREEN_WIDTH / 8, 10);
    final static Point kktextAreaLocation = new Point(3 * (SCREEN_WIDTH / 8), 14 * (SCREEN_HEIGHT / 17) + 3);
    final static String TEXT_DISPLAYED_IN_PASSWORD_BOX = "Please enter your password";
    
    /*********************** KodeKrack Image Locations *****************************/
    final static Point FIREWALL_IMAGE_LOCATION_1 = new Point(1 * (SCREEN_WIDTH / 4), (SCREEN_HEIGHT / 3));
    final static Point FIREWALL_LINE_POINT_1 = new Point(FIREWALL_IMAGE_LOCATION_1.x + 55,
            FIREWALL_IMAGE_LOCATION_1.y + 10);
    final static Point FIREWALL_LINE_POINT_1_THEM = new Point(FIREWALL_IMAGE_LOCATION_1.x + 55,
            FIREWALL_IMAGE_LOCATION_1.y + 150);

    final static Point FIREWALL_IMAGE_LOCATION_2 = new Point(1 * (SCREEN_WIDTH / 2) - 35, (SCREEN_HEIGHT / 3));
    final static Point FIREWALL_LINE_POINT_2 = new Point(FIREWALL_IMAGE_LOCATION_2.x + 35,
            FIREWALL_IMAGE_LOCATION_2.y + 100);
    final static Point FIREWALL_LINE_POINT_2_THEM = new Point(FIREWALL_IMAGE_LOCATION_2.x + 35,
            FIREWALL_IMAGE_LOCATION_2.y + 100);

    final static Point FIREWALL_IMAGE_LOCATION_3 = new Point(3 * (SCREEN_WIDTH / 4) - 40, (SCREEN_HEIGHT / 3));
    final static Point FIREWALL_LINE_POINT_3 = new Point(FIREWALL_IMAGE_LOCATION_3.x + 20,
            FIREWALL_IMAGE_LOCATION_3.y + 10);
    final static Point FIREWALL_LINE_POINT_3_THEM = new Point(FIREWALL_IMAGE_LOCATION_3.x + 20,
            FIREWALL_IMAGE_LOCATION_3.y + 150);

    final static Point OUR_SYSTEM_IMAGE_LOCATION = new Point((SCREEN_WIDTH / 2) - 50, 80);
    final static Point OUR_SYSTEM_LINE_POINT = new Point((SCREEN_WIDTH / 2), 160);

    final static Point THIER_SYSTEM_IMAGE_LOCATION = new Point((SCREEN_WIDTH / 2) - 100, kktextAreaLocation.y - 100);
    final static Point THIER_SYSTEM_LINE_POINT = new Point((SCREEN_WIDTH / 2), kktextAreaLocation.y - 50);

    final static int DELAY = 100_000;
    static boolean buttonIsPressed = false;
    static JPanel kkCenterPanel = new JPanel();

    static Clip failure;
    static Clip subpar;
    static Clip winner;
    static int results = 0;

    public static void main (String[] args)
    {
        // Start a timer which will effectively create a FPS and repaint the screen every-so-often
        Timer timer = new Timer(DELAY, new ActionListener()
        {
            @Override
            public void actionPerformed (ActionEvent e)
            {
                // TODO: This doesn't work... bummer.
                kkCenterPanel.repaint();
            }
        });

        timer.start();

        try
        {
            /******************** Read the necessary audio files from .jar ***********************/
            InputStream is1 = new BufferedInputStream(HackerDisplay.class.getResourceAsStream("/Resources/Fail.wav"));
            AudioInputStream audioInputStream1 = AudioSystem.getAudioInputStream(is1);
            failure = AudioSystem.getClip();
            failure.open(audioInputStream1);

            InputStream is2 = new BufferedInputStream(HackerDisplay.class.getResourceAsStream("/Resources/Mid.wav"));
            AudioInputStream audioInputStream2 = AudioSystem.getAudioInputStream(is2);
            subpar = AudioSystem.getClip();
            subpar.open(audioInputStream2);

            InputStream is3 = new BufferedInputStream(HackerDisplay.class.getResourceAsStream("/Resources/Win.wav"));
            AudioInputStream audioInputStream3 = AudioSystem.getAudioInputStream(is3);
            winner = AudioSystem.getClip();
            winner.open(audioInputStream3);
        }
        catch (Exception ex)
        {
            System.out.println("Oh no Sara, bad things happened.");
            ex.printStackTrace();
        }
        
        //Finally! This is where the magic happens. Set up the KodeKrack view. 
        setUpKodeKrack();
    }

    /**
     * The Decryptor program is used to decrypt a passcode using headquarter's magic decryption software. 
     * The password will be added to the text box and once decrypt is pressed the value will be decrypted 
     * and displayed below. 
     * 
     * Set up the Decryptor view and create a HackerProgram to be used when necessary.
     */
    private static void setUpDecryptor ()
    {
        JPanel centerPanel = new JPanel();
        centerPanel.setBackground(BACKGROUND_COLOR);
        centerPanel.setLayout(null);

        JLabel passcodeLabel = new JLabel("Passcode:");
        passcodeLabel.setName("passcodeLabel");
        passcodeLabel.setFont(TEXT_FONT);
        passcodeLabel.setForeground(Color.RED);
        passcodeLabel.setSize(passcodeLabel.getPreferredSize());
        passcodeLabel.setLocation(PASSWORD_LABEL_LOCATION);
        centerPanel.add(passcodeLabel);

        JLabel hacker = new JLabel("Decryption");
        hacker.setFont(TITLE_TEXT_FONT);
        hacker.setForeground(Color.RED);
        hacker.setSize(hacker.getPreferredSize());
        hacker.setLocation(TITLE_LABEL_LOCATION_START_POINT.x - (hacker.getWidth() / 2),
                TITLE_LABEL_LOCATION_START_POINT.y);
        centerPanel.add(hacker);

        JButton decryptButton = new JButton("Decrypt");
        decryptButton.setFont(TEXT_FONT);
        decryptButton.setForeground(Color.RED);
        decryptButton.setBackground(BACKGROUND_COLOR);
        decryptButton.setLocation(DECRYPT_BUTTON_LOCATION);
        decryptButton.setSize(decryptButton.getPreferredSize());
        decryptButton.setBorderPainted(false);
        centerPanel.add(decryptButton);

        
        JTextField valueToDecryptText = new JTextField("enter me");
        valueToDecryptText.setForeground(Color.GREEN);
        valueToDecryptText.setBackground(BACKGROUND_COLOR);
        valueToDecryptText.setLocation(textAreaLocation);
        valueToDecryptText.setSize(300, 30);
        valueToDecryptText.setBorder(BorderFactory.createLineBorder(BACKGROUND_COLOR));
        centerPanel.add(valueToDecryptText);

        JTextField decryptedValueText = new JTextField();
        decryptedValueText.setForeground(Color.GREEN);
        decryptedValueText.setBackground(BACKGROUND_COLOR);
        decryptedValueText.setLocation(decryptTextAreaLocation);
        decryptedValueText.setSize(300, 50);
        decryptedValueText.setBorder(BorderFactory.createLineBorder(BACKGROUND_COLOR));
        centerPanel.add(decryptedValueText);

        JFrame topLevelFrame = new JFrame();
        topLevelFrame.setSize(topLevelFrame.getPreferredSize());
        topLevelFrame.setContentPane(centerPanel);

        topLevelFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        topLevelFrame.pack();
        topLevelFrame.setExtendedState(JFrame.MAXIMIZED_BOTH);

        JButton goToKodeKrackButton = new JButton("KodeKrack");
        goToKodeKrackButton.setFont(TEXT_FONT);
        goToKodeKrackButton.setForeground(Color.RED);
        goToKodeKrackButton.setBackground(BACKGROUND_COLOR);
        goToKodeKrackButton.setLocation(TOGGLE_PROGRAM_BUTTON_LOCATION);
        goToKodeKrackButton.setSize(goToKodeKrackButton.getPreferredSize());
        goToKodeKrackButton.setBorderPainted(false);
        centerPanel.add(goToKodeKrackButton);

        // This button should enable the KodeKrack view.
        // TODO: I tried to just toggle which panel is visible on this frame but it didn't work.
        goToKodeKrackButton.addActionListener(new ActionListener()
        {
            public void actionPerformed (ActionEvent e)
            {
                setUpKodeKrack();
                topLevelFrame.setVisible(false);
            }
        });

        // When this button is pressed we want to decrypt the value in the valueToDecryptText field.
        decryptButton.addActionListener(new ActionListener()
        {
            public void actionPerformed (ActionEvent e)
            {
                (new HackerProgram(valueToDecryptText, decryptedValueText)).start();
            }
        });

        topLevelFrame.setVisible(true);
    }

    /**
     * KodeKrack is software which headquarters uses to break through the enemies firewall.
     * A password is entered into the password text box and when Hack is pressed the user will either gain access to
     * the enemies drone system or they will be denied access. 
     * 
     * Set's up the GUI for KodeKrack and creates a KodeKrackProgram to run when needed.
     */
    private static void setUpKodeKrack ()
    {
        kkCenterPanel = new JPanel();
        kkCenterPanel.setBackground(BACKGROUND_COLOR);
        kkCenterPanel.setLayout(null);
        JLabel kk = new JLabel("KodeKrack");
        kk.setFont(TITLE_TEXT_FONT);
        kk.setForeground(Color.RED);
        kk.setSize(kk.getPreferredSize());
        kk.setLocation(TITLE_LABEL_LOCATION_START_POINT.x - (kk.getWidth() / 2), TITLE_LABEL_LOCATION_START_POINT.y);
        kkCenterPanel.add(kk);

        JLabel passcodeLabel = new JLabel("Passcode:");
        passcodeLabel.setName("passcodeLabel");
        passcodeLabel.setFont(TEXT_FONT);
        passcodeLabel.setForeground(Color.RED);
        passcodeLabel.setSize(passcodeLabel.getPreferredSize());
        passcodeLabel.setLocation(KK_PASSWORD_LABEL_LOCATION);
        kkCenterPanel.add(passcodeLabel);

        JButton hackButton = new JButton("Hack");
        hackButton.setFont(TEXT_FONT);
        hackButton.setForeground(Color.RED);
        hackButton.setBackground(BACKGROUND_COLOR);
        hackButton.setLocation(HACK_BUTTON_LOCATION);
        hackButton.setSize(hackButton.getPreferredSize());
        hackButton.setBorderPainted(false);
        kkCenterPanel.add(hackButton);

        JButton getResultsButton = new JButton("Get Results");
        getResultsButton.setFont(TEXT_FONT);
        getResultsButton.setSize(getResultsButton.getPreferredSize());
        getResultsButton.setForeground(Color.RED);
        getResultsButton.setBackground(BACKGROUND_COLOR);
        getResultsButton.setLocation(RESULTS_BUTTON_LOCATION);
        getResultsButton.setBorderPainted(false);
        kkCenterPanel.add(getResultsButton);

        JTextField kkText = new JTextField("enter me");
        kkText.setForeground(Color.GREEN);
        kkText.setBackground(BACKGROUND_COLOR);
        kkText.setLocation(kktextAreaLocation);
        kkText.setSize(300, 30);
        kkText.setBorder(BorderFactory.createLineBorder(BACKGROUND_COLOR));
        kkCenterPanel.add(kkText);

        JFrame kkTopLevelFrame = new JFrame();
        kkTopLevelFrame.setSize(kkTopLevelFrame.getPreferredSize());
        kkTopLevelFrame.setContentPane(kkCenterPanel);
        kkTopLevelFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        kkTopLevelFrame.pack();
        kkTopLevelFrame.setExtendedState(JFrame.MAXIMIZED_BOTH);

        JButton goToDecryptorButton = new JButton("Decryptor");
        goToDecryptorButton.setFont(TEXT_FONT);
        goToDecryptorButton.setForeground(Color.RED);
        goToDecryptorButton.setBackground(BACKGROUND_COLOR);
        goToDecryptorButton.setLocation(TOGGLE_PROGRAM_BUTTON_LOCATION);
        goToDecryptorButton.setSize(goToDecryptorButton.getPreferredSize());
        goToDecryptorButton.setBorderPainted(false);
        kkCenterPanel.add(goToDecryptorButton);

        ImageComponent firewall_1 = new ImageComponent("/Resources/firewall.png");
        firewall_1.setLocation(FIREWALL_IMAGE_LOCATION_1);
        kkCenterPanel.add(firewall_1);

        ImageComponent firewall_2 = new ImageComponent("/Resources/firewall.png");
        firewall_2.setLocation(FIREWALL_IMAGE_LOCATION_2);
        kkCenterPanel.add(firewall_2);

        ImageComponent firewall_3 = new ImageComponent("/Resources/firewall.png");
        firewall_3.setLocation(FIREWALL_IMAGE_LOCATION_3);
        kkCenterPanel.add(firewall_3);

        ImageComponent thier_system_image = new ImageComponent("/Resources/smallDrone.png");
        thier_system_image.setLocation(THIER_SYSTEM_IMAGE_LOCATION);
        kkCenterPanel.add(thier_system_image);

        ImageComponent our_system_image = new ImageComponent("/Resources/computerSmall.png");
        our_system_image.setLocation(OUR_SYSTEM_IMAGE_LOCATION);
        kkCenterPanel.add(our_system_image);

        kkCenterPanel.repaint();

        goToDecryptorButton.addActionListener(new ActionListener()
        {
            public void actionPerformed (ActionEvent e)
            {
                setUpDecryptor();
                kkTopLevelFrame.setVisible(false);
            }
        });

        // Plays the results of this game as a sound file.
        getResultsButton.addActionListener(new ActionListener()
        {
            public void actionPerformed (ActionEvent e)
            {
                if (results == 1 || results == 0)
                {
                    failure.start();
                    results = 0;
                }
                else if (results == 2)
                {
                    subpar.start();
                    results = 0;
                }
                else if (results > 2)
                {
                    winner.start();
                    results = 0;
                }
                else
                {
                    failure.stop();
                    subpar.stop();
                    winner.stop();
                }
                
                // Remove old lines to 'refresh' the view. 
                Component[] components = kkCenterPanel.getComponents();
                for (int i = 0; i < components.length; i++)
                {
                    if (components[i] instanceof Line)
                    {
                        kkCenterPanel.remove(components[i]);
                    }
                }

                // For esthetics only, wait for a bit before clearing the screen.
                long timeToLoop = 20_000;
                long startTime = System.currentTimeMillis();
                while (System.currentTimeMillis() - startTime < timeToLoop)
                {
                }
                kkCenterPanel.repaint();
            }
        });
        kkTopLevelFrame.setVisible(true);
        KodeKrackProgram kkp = new KodeKrackProgram(kkText, kkCenterPanel, OUR_SYSTEM_LINE_POINT,
                THIER_SYSTEM_LINE_POINT, FIREWALL_LINE_POINT_1, FIREWALL_LINE_POINT_1_THEM, FIREWALL_LINE_POINT_2,
                FIREWALL_LINE_POINT_2_THEM, FIREWALL_LINE_POINT_3, FIREWALL_LINE_POINT_3_THEM);
        
        // Process the password and display the results. 
        hackButton.addActionListener(new ActionListener()
        {
            public void actionPerformed (ActionEvent e)
            {
                results = kkp.validatePassword(kkCenterPanel, kkText.getText(), results);
                kkText.setText("");
                kkCenterPanel.repaint();
            }
        });
    }
}