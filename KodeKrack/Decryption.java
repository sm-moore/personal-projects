import java.math.BigInteger;
import java.security.MessageDigest;

public class Decryption
{
    /**
     * @return returns the decrypted value of input string.  
     */
    public static String getDecryptedValue(String value_to_decrypt)
    {
        MessageDigest md;
        String hashtext = "";
        try
        {
          //lets perform a 'hash' on this value. 
            byte[] bytesOfMessage = value_to_decrypt.getBytes("UTF-8");
            md = MessageDigest.getInstance("MD5");

            byte[] thedigest = md.digest(bytesOfMessage);
            BigInteger bigInt = new BigInteger(1,thedigest);
            hashtext = bigInt.toString(16);
        }
        catch (Exception e)
        {
            return "8195905";
        }
        return hashtext;
    }
}
