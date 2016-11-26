var rotate = function(nums, k) {
    for(var i = 0;i < k;i++){
        var temp = nums[nums.length - 1];
        nums.pop();
        nums.unshift(temp);
    }
};