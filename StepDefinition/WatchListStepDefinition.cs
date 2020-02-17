using TechTalk.SpecFlow;
using CarGiantProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CarGiantProject.StepDefinition
{
    [Binding]
    public class WatchListStepDefinition
    {
        WishListPage wishListPage;
        CommonSteps commonSteps;

        public WatchListStepDefinition(CommonSteps _commonSteps, WishListPage _wishListPage)
        {
            wishListPage = _wishListPage;
            commonSteps = _commonSteps;
        }
       

        [Given(@"a user clicks the login link")]
        public void GivenAUserClicksTheLoginLink()
        {
            
            wishListPage.SelectLoginLink();
            
        }

        [Given(@"a user enters (.*) in the email field")]
        public void GivenAUserEntersAnEmailInTheEmailField(string emailDetails)
        {
            wishListPage.EnterEmailDetails(emailDetails);
        }

        [Given(@"a user enters (.*) in the password field")]
        public void GivenAUserEntersAPasswordInThePasswordField(string passwordDetails)
        {
            wishListPage.EnterPasswordDetails(passwordDetails);
        }

        [Given(@"a user clicks the sign in button")]
        public void GivenAUserClicksTheSignInButton()
        {
            wishListPage.SelectSignInButton();
            
        }

        [Given(@"a user clicks on home link")]
        public void GivenAUserClicksOnHomeLink()
        {
            wishListPage.SelectHomeButton();
        }

        [Given(@"a user clicks on search link")]
        public void GivenAUserClicksOnSearchLink()
        {
            wishListPage.SelectSearchButton();
        }

        [When(@"a user clicks FirstCar watchlist button")]
        public void WhenAUserClicksFirstCarWatchlistButton()
        {
            wishListPage.SelectFirstCarAddToWatchList();
        }

        [When(@"a user scrols down")]
        public void WhenAUserScrolsDown()
        {
            wishListPage.PageScrollDown();
        }


        [When(@"a user clicks SecondCar watchlist button")]
        public void WhenAUserClicksSecondCarWatchlistButton()
        {
            wishListPage.SelectSecondCarAddToWatchList();
        }

        [When(@"a user clicks on My Garage")]
        public void WhenAUserClicksOnMyGarage()
        {
            wishListPage.SelectMyGarageLink();
        }


        [Then(@"the (.*) should be displayed")]
        public void ThenTheWatchlistShouldBeDisplayed(string expectedWatchListScreen)
        {
            string actualWatchlistScreen = wishListPage.MyWatchListDetails();
            Assert.AreEqual(actualWatchlistScreen, expectedWatchListScreen, "Does not cotain WatchList");

        }

        [When(@"a user clicks on Remove From Watchlist")]
        public void WhenAUserClicksOnRemoveFromWatchlist()
        {
            wishListPage.RemoveItemFromWatchlist();
        }


        [Given(@"a user scrols down")]
        public void GivenAUserScrolsDown()
        {
            wishListPage.PageScrollDown();
        }

        [Given(@"a user clicks on My Garage")]
        public void GivenAUserClicksOnMyGarage()
        {
            wishListPage.SelectMyGarageLink();
        }

        [Given(@"a user clicks on Remove From Watchlist")]
        public void GivenAUserClicksOnRemoveFromWatchlist()
        {
            wishListPage.RemoveItemFromWatchlist();
        }

        [When(@"a user clicks ThirdCar watchlist button")]
        public void WhenAUserClicksThirdCarWatchlistButton()
        {
            wishListPage.SelectThirdCarAddToWatchList();
        }

        [When(@"a user scrols down Twice")]
        public void WhenAUserScrolsDownTwice()
        {
            wishListPage.PageScrollDownTwice();
        }

        [Given(@"a user scrols down fullPage")]
        public void GivenAUserScrolsDownFullPage()
        {
            wishListPage.PageScrollDownFullPage();
        }

        [Then(@"the number of cars remaining (.*) sshould be displayed")]
        public void ThenTheSecondCarVehicleRefSshouldBeDisplayed(string expectedRef)
        {
            string actualRef = wishListPage.SecondCarRefDetails();
            Assert.AreEqual(expectedRef, actualRef, "Ref are not the same");
        }


    }
}
