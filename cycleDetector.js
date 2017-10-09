var obj = {
  foo: {
    name: 'foo',
    bar: {
      name: 'bar',
      baz: {
        name: 'baz',
        aChild: null// 待会将指向obj.foo
      }
    }
  },
  ha: null
}
obj.ha = obj.foo // foo->bar->baz->aChild->foo形成环
JSON.stringify(obj) // => TypeError: Converting circular personucture to JSON


var cache = []
function cycleDetector(obj) {
    Object.getOwnPropertyNames(obj).forEach(function(val, idx, array) {
        if(typeof obj[val] == 'object' && obj[val] !== null){
            var index = cache.indexOf(val)
            if(index > -1) {
                // console.log(obj) // loop start position
                return false
            } else {
                if(obj.hasOwnProperty(val)){
                    console.log(obj.name)
                    console.log(cache.slice(-1)[0])
                    if(obj.name !== cache.slice(-1)[0]){
                        cache = []
                    }
                }
                cache.push(val)
            }
            cycleDetector(obj[val])
        }
    });
    return true
}

cycleDetector(obj)

