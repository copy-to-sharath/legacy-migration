// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Content.Api.Controllers;

[ApiController]
[Route("api/content")]
public sealed class ContentController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\ActiveDiscussions.aspx:1
    [HttpGet("content/activediscussions")]
    public IActionResult Activediscussions()
    {
        return Ok(new { LegacyEndpoint = "/Boards/ActiveDiscussions.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Blog.aspx:1
    [HttpGet("content/blog")]
    public IActionResult Blog()
    {
        return Ok(new { LegacyEndpoint = "/Blog.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Blog.aspx:1
    [HttpGet("content/blog")]
    public IActionResult Blog()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Blog.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogCommentDetails.aspx:1
    [HttpGet("content/blogcommentdetails")]
    public IActionResult Blogcommentdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogCommentDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogComments.aspx:1
    [HttpGet("content/blogcomments")]
    public IActionResult Blogcomments()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogComments.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogHome.aspx:1
    [HttpGet("content/bloghome")]
    public IActionResult Bloghome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogHome.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BlogPost.aspx:1
    [HttpGet("content/blogpost")]
    public IActionResult Blogpost()
    {
        return Ok(new { LegacyEndpoint = "/BlogPost.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostAdd.aspx:1
    [HttpGet("content/blogpostadd")]
    public IActionResult Blogpostadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogPostAdd.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostDetails.aspx:1
    [HttpGet("content/blogpostdetails")]
    public IActionResult Blogpostdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogPostDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BlogRSS.aspx:1
    [HttpGet("content/blogrss")]
    public IActionResult Blogrss()
    {
        return Ok(new { LegacyEndpoint = "/BlogRSS.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogSettings.aspx:1
    [HttpGet("content/blogsettings")]
    public IActionResult Blogsettings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlogSettings.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Default.aspx:1
    [HttpGet("content/default")]
    public IActionResult Default()
    {
        return Ok(new { LegacyEndpoint = "/Boards/Default.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Forum.aspx:1
    [HttpGet("content/forum")]
    public IActionResult Forum()
    {
        return Ok(new { LegacyEndpoint = "/Boards/Forum.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumAdd.aspx:1
    [HttpGet("content/forumadd")]
    public IActionResult Forumadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumAdd.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumDetails.aspx:1
    [HttpGet("content/forumdetails")]
    public IActionResult Forumdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\ForumGroup.aspx:1
    [HttpGet("content/forumgroup")]
    public IActionResult Forumgroup()
    {
        return Ok(new { LegacyEndpoint = "/Boards/ForumGroup.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupAdd.aspx:1
    [HttpGet("content/forumgroupadd")]
    public IActionResult Forumgroupadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumGroupAdd.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupDetails.aspx:1
    [HttpGet("content/forumgroupdetails")]
    public IActionResult Forumgroupdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumGroupDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Forums.aspx:1
    [HttpGet("content/forums")]
    public IActionResult Forums()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Forums.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsHome.aspx:1
    [HttpGet("content/forumshome")]
    public IActionResult Forumshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumsHome.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsSettings.aspx:1
    [HttpGet("content/forumssettings")]
    public IActionResult Forumssettings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ForumsSettings.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueue.aspx:1
    [HttpGet("content/messagequeue")]
    public IActionResult Messagequeue()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MessageQueue.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueueDetails.aspx:1
    [HttpGet("content/messagequeuedetails")]
    public IActionResult Messagequeuedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MessageQueueDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplateDetails.aspx:1
    [HttpGet("content/messagetemplatedetails")]
    public IActionResult Messagetemplatedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MessageTemplateDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplates.aspx:1
    [HttpGet("content/messagetemplates")]
    public IActionResult Messagetemplates()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MessageTemplates.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\MoveTopic.aspx:1
    [HttpGet("content/movetopic")]
    public IActionResult Movetopic()
    {
        return Ok(new { LegacyEndpoint = "/Boards/MoveTopic.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\News.aspx:1
    [HttpGet("content/news")]
    public IActionResult News()
    {
        return Ok(new { LegacyEndpoint = "/Administration/News.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\News.aspx:1
    [HttpGet("content/news")]
    public IActionResult News()
    {
        return Ok(new { LegacyEndpoint = "/News.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsAdd.aspx:1
    [HttpGet("content/newsadd")]
    public IActionResult Newsadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsAdd.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsArchive.aspx:1
    [HttpGet("content/newsarchive")]
    public IActionResult Newsarchive()
    {
        return Ok(new { LegacyEndpoint = "/NewsArchive.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsCommentDetails.aspx:1
    [HttpGet("content/newscommentdetails")]
    public IActionResult Newscommentdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsCommentDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsComments.aspx:1
    [HttpGet("content/newscomments")]
    public IActionResult Newscomments()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsComments.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsDetails.aspx:1
    [HttpGet("content/newsdetails")]
    public IActionResult Newsdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsHome.aspx:1
    [HttpGet("content/newshome")]
    public IActionResult Newshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsHome.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsRSS.aspx:1
    [HttpGet("content/newsrss")]
    public IActionResult Newsrss()
    {
        return Ok(new { LegacyEndpoint = "/NewsRSS.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsSettings.aspx:1
    [HttpGet("content/newssettings")]
    public IActionResult Newssettings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsSettings.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PollAdd.aspx:1
    [HttpGet("content/polladd")]
    public IActionResult Polladd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PollAdd.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PollDetails.aspx:1
    [HttpGet("content/polldetails")]
    public IActionResult Polldetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PollDetails.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Polls.aspx:1
    [HttpGet("content/polls")]
    public IActionResult Polls()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Polls.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\PostEdit.aspx:1
    [HttpGet("content/postedit")]
    public IActionResult Postedit()
    {
        return Ok(new { LegacyEndpoint = "/Boards/PostEdit.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\PostNew.aspx:1
    [HttpGet("content/postnew")]
    public IActionResult Postnew()
    {
        return Ok(new { LegacyEndpoint = "/Boards/PostNew.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrivateMessages.aspx:1
    [HttpGet("content/privatemessages")]
    public IActionResult Privatemessages()
    {
        return Ok(new { LegacyEndpoint = "/PrivateMessages.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Search.aspx:1
    [HttpGet("content/search")]
    public IActionResult Search()
    {
        return Ok(new { LegacyEndpoint = "/Boards/Search.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Topic.aspx:1
    [HttpGet("content/topic")]
    public IActionResult Topic()
    {
        return Ok(new { LegacyEndpoint = "/Boards/Topic.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\TopicEdit.aspx:1
    [HttpGet("content/topicedit")]
    public IActionResult Topicedit()
    {
        return Ok(new { LegacyEndpoint = "/Boards/TopicEdit.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\TopicNew.aspx:1
    [HttpGet("content/topicnew")]
    public IActionResult Topicnew()
    {
        return Ok(new { LegacyEndpoint = "/Boards/TopicNew.aspx", Context = "Content" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Topics.aspx:1
    [HttpGet("content/topics")]
    public IActionResult Topics()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Topics.aspx", Context = "Content" });
    }

}