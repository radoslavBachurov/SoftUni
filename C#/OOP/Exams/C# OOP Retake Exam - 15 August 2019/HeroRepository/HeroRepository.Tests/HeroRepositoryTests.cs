using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository TestHeroRep;
    private Hero testHeroOne;

    [SetUp]
    public void BeforeExecution()
    {
        TestHeroRep = new HeroRepository();
        testHeroOne = new Hero("Stavri", 10);

    }

    [TestCase("If input hero is null you cannot create a hero")]
    public void ValidIfWhenTryToCreateHeroWithNullThrowException(string message)
    {
        Assert.Throws<ArgumentNullException>(() => TestHeroRep.Create(null), message);

        try
        {
            TestHeroRep.Create(null);
        }
        catch (Exception ex)
        {
            string exMessage = ex.Message;
            string expected = "Hero is null\r\nParameter name: hero";

            Assert.AreEqual(expected, exMessage);
        }
    }

    [TestCase("Cant create two heroes with same name")]
    public void ValidIfWhenTryToCreateTwoHeroesWithSameNameThrowsException(string message)
    {
        var testHeroTwo = new Hero("Stavri", 21);
        TestHeroRep.Create(testHeroOne);
        Assert.Throws<InvalidOperationException>(() => TestHeroRep.Create(testHeroTwo), message);
    }

    [TestCase("Dont return accurate message when adding new hero")]
    public void ValidIfWhenReturnsAccurateMessageWhenAddingNewHero(string message)
    {
        string returnMessage = TestHeroRep.Create(testHeroOne);
        Assert.AreEqual(returnMessage, $"Successfully added hero Stavri with level 10", message);
    }

    [TestCase("Cant Remove hero that is null or whitespace")]
    public void ValidIfthrowExceptionWhenTryToRemoveNullOrWhiteSpace(string message)
    {
        Assert.Throws<ArgumentNullException>(() => TestHeroRep.Remove("    "), message);
        Assert.Throws<ArgumentNullException>(() => TestHeroRep.Remove(" "), message);
        Assert.Throws<ArgumentNullException>(() => TestHeroRep.Remove(null), message);
    }

    [TestCase("Must return true if removed a hero")]
    public void ValidIfReturnsTrueWhenHeroIsRemoved(string message)
    {
        TestHeroRep.Create(testHeroOne);
        Assert.True(TestHeroRep.Remove("Stavri"), message);
    }

    [TestCase("Dont return hero with high points")]
    public void ValidIfReturnsHeroWithHighPoints(string message)
    {
        TestHeroRep.Create(testHeroOne);
        TestHeroRep.Create(new Hero("Ivan", 30));
        TestHeroRep.Create(new Hero("Bai", 60));
        Hero returnHero = TestHeroRep.GetHeroWithHighestLevel();
        Assert.AreEqual("Bai", returnHero.Name, message);
    }


    [TestCase("Dont return accurate hero")]
    public void ValidIfReturnsAccurateHero(string message)
    {
        TestHeroRep.Create(testHeroOne);
        TestHeroRep.Create(new Hero("Ivan", 30));
        TestHeroRep.Create(new Hero("Bai", 60));
        Hero returnHero = TestHeroRep.GetHero("Ivan");
        Assert.AreEqual("Ivan", returnHero.Name, message);
    }
}