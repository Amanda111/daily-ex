let state = []
let num = 0

function useState(defaultValue) {
    let setState = function(num, val) {
        state[num] = val
    }
    state[num] = defaultValue
    let setStateFunc = setState.bind(null, num)
    num++
    return [defaultValue, setStateFunc]
}

function Example() {
  const [count, setCount] = useState(0);

  const [name, setName] = useState("lucifer");

  console.log(`${name} clicked ${count} times`);

  setTimeout(() => setCount(count + 1), 1000);

  setTimeout(() => {
    setName("karl");
    setCount(0);
  }, 2000);
}

function Wrapper(component) {
    // state = []
    // num = 0
    component()
}


Wrapper(Example);

console.assert(state[0] === 0, `#1 state[0] should be 0, but got ${state[0]}`);
console.assert(state[1] === "lucifer", `#2 state[1] should be lucifer, but got ${state[1]}`);

setTimeout(() => {
  console.assert(state[0] === 1 , `#3 state[0] should be 1, but got ${state[0]}`);
  console.assert(state[1] === "lucifer", `#4 state[1] should be lucifer, but got ${state[1]}`);
}, 1000);

setTimeout(() => {
  console.assert(state[0] === 0, `#5 state[0] should be 0, but got ${state[0]}`);
  console.assert(state[1] === "karl", `#6 state[1] should be karl, but got ${state[1]}`);
}, 2000);