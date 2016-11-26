//iteratively
var isSymmetric = function(root) {
   if(!root) return true;
   var curr = [root.left,root.right],
       sub = [],
       nullnum = 0;
   while(curr){
       for(var i = 0;i<curr.length;i++){
           if(curr[i] && curr[curr.length -i -1]){
               if(curr[i].val == curr[curr.length - i -1].val){
                   sub.push(curr[i].left,curr[i].right)
               }else{
                   return false;
               }            
           }else if(curr[i] || curr[curr.length - i - 1]){
               return false;
           }else{
               nullnum ++;
           }
       }
       if(nullnum == curr.length) return true;
       curr = sub;
       sub = [];
       nullnum = 0;
   }
};

//recursively
var mirror = function(t1,t2){
    if(t1 === null && t2 === null) return true;
    if(t1 === null || t2 === null) return false;
    return (t1.val == t2.val) && mirror(t1.left,t2.right) && mirror(t1.right,t2.left);
};

var isSymmetric = function(root) {
   return mirror(root,root);
};