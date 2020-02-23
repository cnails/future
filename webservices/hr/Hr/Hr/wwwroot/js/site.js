// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//import 'animate.css'
//import 'fullpage-vue/src/fullpage.css' 
var Main = {
    data: function () {
        var that = this;
        return {
            index: 0,
            pageNum: 0,
            disabled: false,
            opts: {
                start: 0,
                dir: 'v',
                loop: false,
                duration: 300,
                beforeChange: function (ele, current, next) {
                    console.log('before', current, next)
                    that.index = next;
                },
                afterChange: function (ele, current) {
                    that.index = current;
                    console.log('after', current)
                }
            }
        };
    },
    methods: {
        moveTo: function (index) {
            this.$refs.fullpage.$fullpage.moveTo(index, true);
        },
        moveNext: function () {
            this.$refs.fullpage.$fullpage.moveNext();
            console.log("next")

        },
        showPage: function () {
            this.pageNum++;
            this.$refs.fullpage.$fullpage.$update();
        },
        setDisabled() {
            this.disabled = !this.disabled
            this.$refs.fullpage.$fullpage.setDisabled(this.disabled)
        }
    }
}
var Ctor = Vue.extend(Main)
var app = new Ctor().$mount('#app')
