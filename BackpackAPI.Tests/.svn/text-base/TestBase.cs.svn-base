using System.Configuration;
using jonezy.org.BackpackAPI.Interfaces;
using jonezy.org.BackpackAPI;

namespace BackpackTests
{
    /// <summary>
    /// Base class for all test to inherit from, populates commonly used variables.
    /// </summary>
    public class TestBase
    {
        // services used in test classes
        public IPageService pageService = null;
        public IJournalService journalService = null;
        public IListsService listsService = null;
        public IListItemsService listItemsService = null;
        public INotesService notesService = null;
        public ISeparatorService separatorService = null;
        public IStatusService statusService = null;
        public ITagsService tagsService = null;
        public IUserService userService = null;

        // test data specified in app.config and used by test classes
        public string testPageId = string.Empty;
        public string testUserId = string.Empty;
        public string testInvalidUserId = string.Empty;
        public string testTagId = string.Empty;
        public string testPageTitle = string.Empty;
        
        public void TestSetup()
        {
            pageService = new PageService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            journalService = new JournalService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            listsService = new ListsService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            listItemsService = new ListItemsService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            notesService = new NotesService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            separatorService = new SeparatorService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            statusService = new StatusService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            tagsService = new TagsService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());
            userService = new UserService(ConfigurationSettings.AppSettings["backpack.account.name"].ToString(), ConfigurationSettings.AppSettings["backpack.account.token"].ToString());

            testPageId = ConfigurationSettings.AppSettings["backpack.pages.testpage"].ToString();
            testUserId = ConfigurationSettings.AppSettings["backpack.users.testuserid"].ToString();
            testInvalidUserId = ConfigurationSettings.AppSettings["backpack.users.testinvaliduserid"].ToString();
            testTagId = ConfigurationSettings.AppSettings["backpack.pages.testtagid"].ToString();
            testPageTitle = ConfigurationSettings.AppSettings["backpack.pages.testpagetitle"].ToString();

        }
    }
}
