import { addMentionNodes, addTagNodes, getMentionsPlugin } from 'prosemirror-mentions';

let _dotnetRef;
window.initializeMentions = (dotnetRef) => {
    _dotnetRef = dotnetRef;
}

/**
 * IMPORTANT: outer div's "suggestion-item-list" class is mandatory. The plugin uses this class for querying.
 * IMPORTANT: inner div's "suggestion-item" class is mandatory too for the same reasons
 */
var getMentionSuggestionsHTML = items => '<div class="suggestion-item-list">' +
    items.map(i => '<div class="suggestion-item">' + i.name + '</div>').join('') +
    '</div>';

/**
 * IMPORTANT: outer div's "suggestion-item-list" class is mandatory. The plugin uses this class for querying.
 * IMPORTANT: inner div's "suggestion-item" class is mandatory too for the same reasons
 */
var getTagSuggestionsHTML = items => '<div class="suggestion-item-list">' +
    items.map(i => '<div class="suggestion-item">' + i.tag + '</div>').join('') +
    '</div>';

let mentionSuggestionsHTML = null;
let tagSuggestionsHTML = null;

var mentionPlugin = getMentionsPlugin({
    getSuggestions: (type, text, done) => {
        setTimeout(async () => {
            if (type === 'mention') {
                try {
                    const suggestions = await _dotnetRef.invokeMethodAsync('GetMentionSuggestionsAsync', text);
                    mentionSuggestionsHTML = await _dotnetRef.invokeMethodAsync('GetMentionSuggestionsHTML', suggestions);
                    done(suggestions);
                } catch (error) {
                    console.error('Error getting suggestions:', error);
                    done([]);
                }
            } else if(type === 'tag') {
                try {
                    const tagSuggestions = await _dotnetRef.invokeMethodAsync('GetTagSuggestionsAsync', text);
                    tagSuggestionsHTML = await _dotnetRef.invokeMethodAsync('GetTagSuggestionsHTML', tagSuggestions);
                    done(tagSuggestions);
                } catch (error) {
                    console.error('Error getting suggestions:', error);
                    done([]);
                }
            }
        }, 0);
    },
    getSuggestionsHTML: (items, type) => {
        if (type === 'mention') {
            return mentionSuggestionsHTML;
        } else if (type === 'tag') {
            return tagSuggestionsHTML;
        }
    }
});

window.pluginsProvider = (args) => {
    const schema = args.getSchema();

    return [mentionPlugin, ...args.getPlugins(schema)];
}

window.schemaProvider = (args) => {
    const schema = args.getSchema();
    const Schema = args.ProseMirror.Schema;
    const nodes = addTagNodes(addMentionNodes(schema.spec.nodes));
    const mentionsSchema = new Schema({
        nodes: nodes,
        marks: schema.spec.marks
    });

    return mentionsSchema;
}
