internal class Program
{
    private static void Main(string[] args)
    {
        //Example-1
        Ogrenci ogr1 = new Ogrenci("Ayşe", "Yılmaz", 233, 3);
        Ogrenci ogr2 = new Ogrenci("Pelin", "Aksu", 256, 4);

        ogr1.OgrenciBilgileriGetir();
        ogr2.OgrenciBilgileriGetir();

        ogr1.SinifAtlat();
        ogr2.SinifDusur();

        ogr1.OgrenciBilgileriGetir();
        ogr2.OgrenciBilgileriGetir();

        Ogrenci ogr3 = new Ogrenci("Deniz", "Ada", -1, 0);
        ogr3.OgrenciBilgileriGetir();
        ogr3.SinifDusur();


        //Example-2
        string userName, userPassword, mark = new string('-', 6);
        DatabaseManager dbManager = new DatabaseManager();
        Console.WriteLine("{0}\n< C# Kapsülleme Örnekleri #1 >\n{1}", mark, mark);
        Console.Write("-> İsminizi Girin: ");
        dbManager.setLoginName = Console.ReadLine();
        Console.Write("{0}\n-> Lütfen veritabanı kullanıcı adını girin: ", mark);
        userName = Console.ReadLine();
        Console.Write("-> Lütfen veritabanı kullanıcı şifresini girin: ");
        userPassword = Console.ReadLine();
        if (dbManager.checkName == userName && dbManager.checkPassword == userPassword)
        {
            dbManager.dbLogin();
        }
        else
            Console.WriteLine("{0}\n-> Giriş gerçekleştirilemedi.\n{1}", mark, mark);

        //Example-3
        ReadDepartment d = new ReadDepartment("COMPUTERSCIENCE");
        Console.WriteLine("The Department is: {0}", d.Departname);

        //Example-4
        WriteDepartment b = new WriteDepartment();
        b.Departname = "COMPUTERSCIENCE";


    }
}


//Example-Class-1
class Ogrenci
{
    private string isim;
    private string soyisim;
    private int ogrno;
    private int sinif;

    public string Isim { get => isim; set => isim = value; }
    public string Soyisim { get => soyisim; set => soyisim = value; }
    public int Ogrno
    {
        get => ogrno;
        set
        {
            if (value > 0)
                ogrno = value;
            else
                Console.WriteLine("Ögrenci numarası 0'dan büyük olmalı!");
        }
    }
    public int Sinif
    {
        get { return sinif; }
        set
        {
            if (value < 1)
            {
                Console.WriteLine("Sınıf En Az 1 Olabilir!");
                sinif = 1;
            }
            else
                sinif = value;
        }
    }

    public Ogrenci(string ısim, string soyisim, int ogrno, int sinif)
    {
        Isim = ısim;
        Soyisim = soyisim;
        Ogrno = ogrno;
        Sinif = sinif;
    }
    public Ogrenci() { }

    public void OgrenciBilgileriGetir()
    {
        Console.WriteLine("\n-Öğrenci Bilgileri-");
        Console.WriteLine("Ögrenci Adı      :{0}", this.Isim);
        Console.WriteLine("Ögrenci Soyadı   :{0}", this.Soyisim);
        Console.WriteLine("Ögrenci No       :{0}", this.Ogrno);
        Console.WriteLine("Ögrenci Sınıf    :{0}\n", this.Sinif);
    }

    public void SinifAtlat()
    {
        this.Sinif = this.Sinif + 1;
    }

    public void SinifDusur()
    {
        this.Sinif = this.Sinif - 1;
    }

}


//Example-Class-2
class DatabaseManager
{
    private string dbUserName = "root", dbPassword = "admin", mark = new string('-', 6), dbLoginName;
    public string checkName
    {
        get
        {
            return dbUserName;
        }
    }
    public string checkPassword
    {
        get
        {
            return dbPassword;
        }
    }
    public string setLoginName
    {
        set
        {
            dbLoginName = value;
        }
    }
    public void dbLogin()
    {
        Console.WriteLine("{0}\n< Database Bağlantısı Oluştu >\n{1}", mark, mark);
        Console.WriteLine("-> Bağlantı sağlayan kişi: {0}\n-> Bağlantı sağlanan zaman : {1}\n{2}", dbLoginName, DateTime.Now.ToString("dd/MM/yyyy HH:mm"), mark);
    }

}

//READ ONLY PROPERTY
public class ReadDepartment
{
    private string departname;
    public ReadDepartment(string avalue)
    {
        departname = avalue;
    }
    public string Departname
    {
        get
        {
            return departname;
        }
    }
}

//WRITE ONLY PROPERTY
public class WriteDepartment
{
    private string departname;
    public string Departname
    {
        set
        {
            departname = value;
            Console.WriteLine("The Department is :{0}", departname);
        }
    }
}

