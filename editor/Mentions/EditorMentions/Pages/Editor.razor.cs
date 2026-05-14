using EditorMentions.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.JSInterop;

namespace EditorMentions.Pages
{
    public partial class Editor : IDisposable
    {
        private DotNetObjectReference<Editor>? _dotNetRef;

        #region Sample Data
        private List<Mention> Mentions { get; set; } = new List<Mention>()
        {
            new()
            {
                Id = "board",
                Name = "Jane Simons",
                Email = "jane.simons@company.com",
            },
            new()
            {
                Id = "engineering",
                Name = "Peter Parker",
                Email = "peter.parker@company.com"
            },
            new()
            {
                Id = "generalManager",
                Name = "Liam Turner",
                Email = "liam.turner@company.com"
            }
        };

        private List<Tag> Tags { get; set; } = new List<Tag>()
        {
            new()
            {
                Text = "Blazor"
            },
            new()
            {
                Text = "Telerik"
            }
        };
        #endregion

        #region DI
        [Inject]
        private IJSRuntime JSRuntime { get; set; } = null!;

        [Inject]
        private IServiceProvider ServiceProvider { get; set; } = null!;
        #endregion

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _dotNetRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("initializeMentions", _dotNetRef);
            }
        }

        #region Mentions
        [JSInvokable]
        public async Task<Mention[]> GetMentionSuggestionsAsync(string text)
        {
            return Mentions.Where(mention => mention.Name.ToLower().Contains(text.ToLower())).ToArray();
        }

        [JSInvokable]
        public async Task<string> GetMentionSuggestionsHTML(List<Mention> mentions)
        {
            using var htmlRenderer = new HtmlRenderer(ServiceProvider, NullLoggerFactory.Instance);
            var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
            {
                var dictionary = new Dictionary<string, object?>
                {
                    { "Items", mentions }
                };
                var parameters = ParameterView.FromDictionary(dictionary);
                var output = await htmlRenderer.RenderComponentAsync<MentionSuggestionsList>(parameters);
                return output.ToHtmlString();
            });

            return html;
        }
        #endregion

        #region Tags
        [JSInvokable]
        public async Task<Tag[]> GetTagSuggestionsAsync(string text)
        {
            return Tags.Where(tag => tag.Text.ToLower().Contains(text.ToLower())).ToArray();
        }

        [JSInvokable]
        public async Task<string> GetTagSuggestionsHTML(List<Tag> tags)
        {
            using var htmlRenderer = new HtmlRenderer(ServiceProvider, NullLoggerFactory.Instance);
            var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
            {
                var dictionary = new Dictionary<string, object?>
                {
                    { "Items", tags }
                };
                var parameters = ParameterView.FromDictionary(dictionary);
                var output = await htmlRenderer.RenderComponentAsync<TagSuggestionsList>(parameters);
                return output.ToHtmlString();
            });
            return html;
        }
        #endregion

        public void Dispose()
        {
            _dotNetRef?.Dispose();
        }
    }
}
