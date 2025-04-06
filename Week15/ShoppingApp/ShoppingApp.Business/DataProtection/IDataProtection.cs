namespace ShoppingApp.Business.DataProtection
{
    public interface IDataProtection
    {
        // the text sent is encrypted
        string Protect(string text);


        // ciphertext is decrypted
        string Unprotect(string protectedText);
    }
}