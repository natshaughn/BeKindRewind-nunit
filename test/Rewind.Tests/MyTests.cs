namespace Rewind.Tests;

using Rewind;

public class MyTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SanityCheckRewindBaseTwo()
    {
        RewindBase rewind = new RewindBase("Hi");
        Assert.That(rewind.GetName(), Is.EqualTo("Hi"));
    }

    [Test]
    public void SanityCheckRewindMemberTwo()
    {
        RewindMember rewind = new RewindMember("Hi", 100);
        Assert.That(rewind.GetMembershipId(), Is.EqualTo("#000100"));
    }

    [Test]
    public void SanityCheckRewindMovieTwo()
    {
        RewindMovie rewind = new RewindMovie("Mary Poppins", "Comedy", 1964);
        Assert.That(rewind.GetId().Length, Is.EqualTo(36));
        Assert.That(rewind.GetName(), Is.EqualTo("Mary Poppins"));
        Assert.That(rewind.GetGenre(), Is.EqualTo("Comedy"));
        Assert.That(rewind.GetYear(), Is.EqualTo("1964"));
    }



    [Test]
    public void SanityCheckRewindStockTwo()
    {
        RewindStock rewind = new RewindStock();
        Assert.That(rewind.GetTotal(), Is.EqualTo(0));
        Assert.That(rewind.GetCount("Mary Poppins", "Comedy", 1964), Is.EqualTo(0));
        rewind.Add("Mary Poppins", "Comedy", 1964);
        rewind.Add("Mary Poppins", "Comedy", 1964);
        Assert.That(rewind.GetTotal(), Is.EqualTo(2));
        Assert.That(rewind.GetCount("Mary Poppins", "Comedy", 1964), Is.EqualTo(2));
    }

    [Test]
    public void AddRemoveStock()
    {
        RewindStock rewind = new RewindStock();
        Assert.That(rewind.GetTotal(), Is.EqualTo(0));
        Assert.That(rewind.GetCount("Mary Poppins", "Comedy", 1964), Is.EqualTo(0));
        rewind.Add("Mary Poppins", "Comedy", 1964);
        rewind.Add("Mary Poppins", "Comedy", 1964);
        rewind.Add("Mary Poppins", "Comedy", 1964);
        rewind.Add("Titanic", "Horror", 1996);
        rewind.RemoveMovie("Mary Poppins", "Comedy", 1964);
        Assert.That(rewind.GetTotal(), Is.EqualTo(3));
        Assert.That(rewind.GetCount("Mary Poppins", "Comedy", 1964), Is.EqualTo(2));
        Assert.That(rewind.GetCount("Titanic", "Horror", 1996), Is.EqualTo(1));
    }

    [Test]
    public void SanityCheckRewindStoreTwo()
    {
        RewindStock stock = new RewindStock();
        stock.Add("Mary Poppins", "Comedy", 1964);
        RewindStore store = new RewindStore(stock);
        Assert.That(store.CheckStock("Mary Poppins", "Comedy", 1964), Is.EqualTo(1));
    } 

    [Test]
    public void Store()
    {
        RewindStock stock = new RewindStock();
        stock.Add("Mary Poppins", "Comedy", 1964);
        RewindStore store = new RewindStore(stock);
        Assert.That(store.CheckStock("Mary Poppins", "Comedy", 1964), Is.EqualTo(1));
        RewindMember rewind = new RewindMember("Hi", 100);
        Assert.That(rewind.GetMembershipId(), Is.EqualTo("#000100"));
        Assert.That(store.CheckStock("Mary Poppins", "Comedy", 1964), Is.EqualTo(1));
        RewindMovie movie = new RewindMovie("Mary Poppins", "Comedy", 1964);
        // Functionality not completed in this class to carry on with testing other functions
    }


    [Test]
    public void SanityCheckRewindMovieThrow()
    {
        try
        {
            RewindStock stock = new RewindStock();
            stock.Add("Hot Rod", "Comedy", 2007);
            Assert.Fail();
        } 
        catch (Exception)
        {
            Assert.Pass();
        }
    }

}
       

