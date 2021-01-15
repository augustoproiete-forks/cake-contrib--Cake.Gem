
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"GemArgumentBuilder",
            content:"GemArgumentBuilder",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem/GemArgumentBuilder_1',
            title:"GemArgumentBuilder<T>",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"GemBuildRunner",
            content:"GemBuildRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem.Build/GemBuildRunner',
            title:"GemBuildRunner",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"GemPushRunner",
            content:"GemPushRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem.Push/GemPushRunner',
            title:"GemPushRunner",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"GemAliases",
            content:"GemAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem/GemAliases',
            title:"GemAliases",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"GemTool",
            content:"GemTool",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem/GemTool_1',
            title:"GemTool<TSettings>",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"GemPushSettings",
            content:"GemPushSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem.Push/GemPushSettings',
            title:"GemPushSettings",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"GemBuildSettings",
            content:"GemBuildSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem.Build/GemBuildSettings',
            title:"GemBuildSettings",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"GemSettings",
            content:"GemSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.Gem/api/Cake.Gem/GemSettings',
            title:"GemSettings",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
