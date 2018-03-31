function PromiseB(func){
    this.status = "pending"
    this.value = ""
    this.resolveFn = function () {}
    this.rejectFn = function () {}
    this.excu(func)
}

PromiseB.prototype.excu = function(func){
    // var that = this
    // func(function(val){
    //     setTimeout(function(){
    //         that.resolveFn(val)
    //     },0)
    // },function(val){
    //     setTimeout(function(){
    //         that.rejectFn(val)
    //     },0)
    // })
    func(this.resolve.bind(this),this.reject.bind(this))
}

PromiseB.prototype.resolve = function(val){
    var that = this
    this.value = val
    if(this.status == "pending"){
        setTimeout(function(){
            that.resolveFn(val)
        },0)
        this.status = "resolved"
    }
}

PromiseB.prototype.reject = function(val){
    var that = this
    this.value = val  
    if(this.status == "pending"){       
        setTimeout(function(){
            that.rejectFn(val)
        },0)
        this.status = "rejected"
    }
}

PromiseB.prototype.then = function(resolveFn,rejectFn){
    var that = this
    return new PromiseB(function(resolve,reject){
        function resolveNextFn(val){
            var preResult = resolveFn(val)   
            if(preResult instanceof PromiseB){
                preResult.then(resolve,reject)
            }else{
                resolve(preResult)
            }            
        }
        function rejectNextFn(val){
            var preResult = rejectFn(val)
            if(preResult instanceof PromiseB){
                preResult.then(resolve,reject)
            }else{
                reject(preResult)
            }
        }
        that.resolveFn = resolveNextFn
        that.rejectFn = rejectNextFn
    })
}

// PromiseB.prototype.then = function(resolveFn,rejectFn){
//     this.resolveFn = resolveFn
//     this.rejectFn = rejectFn
// }

PromiseB.all = function(){
    var argArr = Array.prototype.slice.call(arguments)[0]
    var arrList = []
    var tag = argArr.every(function(item){        
        if(item instanceof PromiseB){
            arrList.push(item.value)
            return item.status == 'resolved'
        }else{
            arrList.push(item)
        }
    })
    if(tag){
        return new PromiseB(function(resolve,reject){
            resolve(arrList)
        })
    }else{
        return new PromiseB(function(resolve,reject){        
            reject(arrList.pop())
        })
    }
}

// ---------   test   -----------

var testPromise = new PromiseB(function (resolve, reject) {
    resolve('hello')  
}).then(function (data) {
    console.log(data)
    return "hi"
}).then(function(data){
    console.log(data);
    return new PromiseB(function(resolve,reject){
        resolve("handle it")
    })
}).then(function(data){
    console.log(data)
});

var p1 = new PromiseB(function(resolve,reject){
    resolve('p1')
})
var p2 = new PromiseB(function(resolve,reject){
    resolve('p2')
})
var p3 = new PromiseB(function(resolve,reject){
    reject('p3')
})

PromiseB.all([p1,p2,p3]).then(function(data){
    console.log(data)
},function(data){
    console.log(data)
})