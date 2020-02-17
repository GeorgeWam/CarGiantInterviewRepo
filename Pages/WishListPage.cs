using OpenQA.Selenium;
using System.Threading;
using CarGiantProject.Hooks;




namespace CarGiantProject.Pages
{
    public class WishListPage
    {

        Context context;

        public WishListPage (Context _context)
        {
            context = _context;

        }

        //Identifying Elements
        By clickingLoginLink = By.XPath("/html/body/section[1]/header/div[1]/div/div[2]/a[1]");
        By emailField = By.Id("PartialLogin_Username");
        By passwordField = By.Id("PartialLogin_Password");
        By signInButton = By.CssSelector("body > section.site-body > section.mygarage-login > div:nth-child(2) > div.large-6.medium-6.small-12.columns.open > div.flip-container > div > div.front > form > div.btn-wrap > input");
        By homeButton = By.XPath("/html/body/section[1]/section[1]/div/ul/li[1]/a");
        By searchButton = By.CssSelector("#tabs-simple-search > div > div.left-side.columns > form > div.row.fat > div.search-controls-wrap.columns.medium-12 > div.show-for-large-up > button");
        By firstCarWatchList = By.CssSelector("#tour_anchor_for_watchlist");
        By secondCarWatchList = By.CssSelector("#vehicle-results-panel > ul > li:nth-child(2) > article > div.vehicle-tile__column.vehicle-tile__column--first > div > a.vehicle-tile__action.watchlist-btn.is--add.hidden--small");
        By myGarageLink = By.XPath("/html/body/section[1]/header/div[1]/div/div[2]/a");
        By removeFromWatchlist = By.CssSelector("#slick-slide00 > div.large-8.medium-8.small-12.columns > p > a > i");
        By thirdCarWatchList = By.CssSelector("#vehicle-results-panel > ul > li:nth-child(3) > article > div.vehicle-tile__column.vehicle-tile__column--first > div > a.vehicle-tile__action.watchlist-btn.is--add.hidden--small");
        By secondCarRef = By.CssSelector("/html/body/section[1]/section[3]/div[2]/div[2]/span[2]/ul/li[2]/button");


        // Writing methods for the elements
        public void SelectLoginLink()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(clickingLoginLink).Click();
        }

        public void EnterEmailDetails(string emailDetails)
        {
            Thread.Sleep(2000);
            var emailDetailsField = context.driver.FindElement(emailField);
            emailDetailsField.Clear();
           emailDetailsField.SendKeys(emailDetails);
        }

        public void EnterPasswordDetails(string passwordDetails)
        {
            Thread.Sleep(2000);
            var passwordDetailsField = context.driver.FindElement(passwordField);
            passwordDetailsField.Clear();
            passwordDetailsField.SendKeys(passwordDetails);
        }

        public void PageScrollDown()
        {
            Thread.Sleep(2000);
            var js = (IJavaScriptExecutor)context.driver;

            js.ExecuteScript("window.scrollTo(document.body.scrollHeight,250)");
        }

        public void PageScrollDownTwice()
        {
            Thread.Sleep(2000);
            var js = (IJavaScriptExecutor)context.driver;

            js.ExecuteScript("window.scrollTo(document.body.scrollHeight,650)");
        }

        public void PageScrollDownFullPage()
        {
            Thread.Sleep(2000);
            var js = (IJavaScriptExecutor)context.driver;

            js.ExecuteScript("window.scrollTo(document.body.scrollHeight,450)");
        }

        public void SelectSignInButton()
        {
            Thread.Sleep(2000);
            
            
            context.driver.FindElement(signInButton).Click();
         
        }

        public void SelectHomeButton()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(homeButton).Click();
        }

        public void SelectSearchButton()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(searchButton).Click();
        }

        public void SelectFirstCarAddToWatchList()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(firstCarWatchList).Click();
        }

        public void SelectSecondCarAddToWatchList()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(secondCarWatchList).Click();
        }

        public void SelectThirdCarAddToWatchList()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(thirdCarWatchList).Click();
        }

        public void SelectMyGarageLink()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(myGarageLink).Click();
        }


        public string MyWatchListDetails()
        {
            Thread.Sleep(2000);
            return context.driver.Url.Trim();
        }

        public void RemoveItemFromWatchlist()
        {
            Thread.Sleep(2000);
            context.driver.FindElement(removeFromWatchlist).Click();
        }

        public string SecondCarRefDetails()
        {
            return context.driver.FindElement(secondCarRef).Text.Trim();
            
           
        }

        


    }
}
