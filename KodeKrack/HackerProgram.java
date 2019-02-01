import javax.swing.JTextField;

/**
 * Creates the model behind Decryptor. Decrypts the value in the text field and aside from some eye candy, places the
 * decrypted value in the given text area.
 * 
 * @author Sara Adamson
 */
public class HackerProgram extends Thread
{
    private JTextField placeForDecryptedValue;
    private JTextField valueToDecrypt;

    public HackerProgram (JTextField valueToDecrypt, JTextField placeForDecryptedValue)
    {
        this.placeForDecryptedValue = placeForDecryptedValue;
        this.valueToDecrypt = valueToDecrypt;
    }

    public void run ()
    {
        String[] loading = { ".", ".", ".", "d", "e", "c", "r", "y", "p", "t", "i", "n", "g", ".", ".", ".", ".", "." };
        String value = Decryption.getDecryptedValue(valueToDecrypt.getText());

        long timeBetween = 100_000_000; // wait one second
        int index = 0;
        int count = 0;
        while (count < 5)
        {
            // for eye candy, wait a bit between displaying the elements in the 'decrypting' message to the user.
            long startTime = System.nanoTime();
            while (System.nanoTime() - startTime < timeBetween)
            {
            }

            // display the 'decrypting' message.  
            if (index < loading.length)
            {
                placeForDecryptedValue.setText(placeForDecryptedValue.getText() + loading[index]);
            }
            // clear the remnants of the 'decrypting' message
            else if (index == loading.length)
            {
                count++;
                index = -1;
                placeForDecryptedValue.setText("");
            }
            index++;
        }
        
        // Display the decrypted value to the user. 
        placeForDecryptedValue.setText(value);
    }
}
