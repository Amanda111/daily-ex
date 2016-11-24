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