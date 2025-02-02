using MarsQA.Pages;
using MarsQA.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace MarsQA.StepDefinitions
{
    [Binding]
    public class DescriptionFeature1StepDefinitions : CommonDriver
    {
        //public IWebDriver driver;
        
        ProfilePage profilePageObj = new ProfilePage();
        SignIn signInObj = new SignIn();
        ProfilePage DeletePageObj = new ProfilePage();
        ProfilePage EditPageObj = new ProfilePage();



        [Given(@"I came to the website")]
        public void GivenICameToTheWebsite()
        {
            //driver = new ChromeDriver();

            //Home Page Object initalization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToSignPage(driver);
        }

        [When(@"I navigate to the Profile page")]
        public void WhenINavigateToTheProfilePage()
        {
            //SignIn Page Object initalization and definition


            signInObj.SignInActions(driver);
        }

        [When(@"I create new Description")]
        public void WhenICreateNewDescription()
        {
            
            profilePageObj.CreateDescription(driver);
        }

        [Then(@"Description should be created successfully")]
        public void ThenDescriptionShouldBeCreatedSuccessfully()
        {
            
            string newDescription = profilePageObj.GetDescription(driver);

            Assert.That(newDescription == "An organized candidate is a detail-oriented person an employer can trust to meet deadlines.", " Actual description and expected description do not match.");
        }
        //[When(@"I updated '([^']*)' on existing Description record")]
        //public void WhenIUpdatedOnExistingDescriptionRecord(string certificationName)
        //{
        //    profilePageObj.UpdateDescription(driver);
        //}
        //[Then(@"Then the Description record should be created successfully")]
        //public void ThenThenTheDescriptionRecordShouldBeCreatedSuccessfully(string certificationName)
        //{
        //    string newAwards = profilePageObj.UpdateDescription(driver);
        //    Assert.That(newAwards == "certificationName", "Actual description and expected description do not match.");
        //}
        [When(@"I updated '([^']*)','([^']*)' on existing Description record")]
        public void WhenIUpdatedOnExistingDescriptionRecord(string CertificationName, string putDescription)
        {
            EditPageObj.editDescription(driver,CertificationName, putDescription);
        }
        [Then(@"Then the record should be created successfully '([^']*)','([^']*)'")]
        public void ThenThenTheRecordShouldBeCreatedSuccessfully(string CertificationName, string putDescription)
        {
            string newAwards = EditPageObj.UpdateDescription(driver);
            string newdescription = EditPageObj.newUpdatedDescription(driver);


            Assert.That(newAwards == CertificationName, "Actual description and expected description do not match.");
            Assert.That(newdescription == putDescription, "Actual description and expected description do not match.");
        }



        [When(@"I deleted existing Certification")]
        public void WhenIDeletedExistingCertification()
        {
            DeletePageObj.deleteCertification(driver);
        }
        [Then(@"Then the Certification should be deleted")]
        public void ThenThenTheCertificationShouldBeDeleted()
        {
            string newdeleted = DeletePageObj.GetDeleted(driver);
            Assert.That( newdeleted!= "NetRiders Challenge 2011","Actual description and expected description do not match");
        }


    }
}
