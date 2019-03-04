const bindViewToData = (el, data) => {
    let dataNodes = []
    let dataTemp = []
    const searchText = (el) => {
        el.childNodes.forEach(e => {
            if(!(e instanceof Text)) {
                searchText(e)
            }else{
                let current = e.textContent.trim()
                if(current.length > 0 && /{\s*{[^}]+}\s*}/.test(current)){
                    dataNodes.push(el)
                    dataTemp.push(el.textContent.replace(/{\s*{/g,'${').replace(/}\s*}/g,'}'))
                }
            }
        });
    }
    searchText(el)
  
    const updateView = () => {
        // console.log(dataNodes,dataTemp)
        dataNodes.forEach((el,i) => {
            console.log(el,i)
            with(data){
                el.textContent = eval(`${`\`${dataTemp[i].trim()}\``}`)
            }
        })
    }
    updateView()
    
    // ES5 Object.defineProperties
    Object.keys(data).forEach(key => {
        let initialVal = data[key]
        Object.defineProperty(data,key,{
            get() {
                return initialVal
            },
            set(newValue) {
                initialVal = newValue
                updateView()
            }
        })
    })
}
  