var containsDuplicate = function(nums) {
    var hash = {},
        value,
        i = 0;
    while(i<nums.length){
        value = nums[i];
        if(value in hash){
            return true;
        }else{
            hash[value] = "haha";
        }
        i++;
    }
    return false;
};