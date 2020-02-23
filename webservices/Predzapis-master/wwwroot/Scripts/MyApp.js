
var date = new Date;
function today() {
    var dayW = new Date();
    var dd = dayW.getDate();
    if (dd.toString().length < 2) {
        dd = "0" + dd
    }
    var mm = dayW.getMonth() + 1;
    if (mm.toString().length < 2) {
        mm = "0" + mm
    }
    var yyyy = dayW.getFullYear();
    var td = dd + '.' + mm + '.' + yyyy;
    return td;
}

document.addEventListener("DOMContentLoaded", function (event) {
    Vue.component('modal', {
        template: '#modal-template',
        methods: {
            onChange: function (event) {
                var thisvue = this;
                hh = this.$parent;
                //console.log(this.$slots.body[0].children[1].elm);
                dd = hh.$attrs.data;
                //console.log();
                dd.person = this.$slots.body[0].children[1].elm.previousElementSibling.value
                dd.leading = this.$slots.body[0].children[1].elm.nextElementSibling.value

                //"%cТехт", "font-size: 20px; color: blue;"
                mes = "%cОтправка Время:" + hh._props.name + " ИМЯ: " + hh.$attrs.data.person + "\nПригласил: " + hh.$attrs.data.leading;
                console.log(mes, 'font-size:24px;color: #bada55')



                this.$root.connection.invoke('SendMessage', dd.person, dd.leading, dd.name, hh.$parent.name, dd.id, dd.edit).catch(function (err) {
                    return console.error(err);
                });
                Send = err;
                //console.log('%cSEND', 'font-size:24px;color: red');

            }

        },
    });

    Vue.component('windows-info', {
        template: '#window',
        props: ['name', 'hr'],
    });


    Vue.component('hr-info', {
        template: '#hr',
        component: 'modal',
        props: ['name', 'person', 'leading', 'showModal', 'edit'],
    });



    var app = new Vue({

        el: '#chatApp',

        data: {
            week: 0,
            //showModal: false,
            days: [
                {
                    name: 'Понедельник',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Вторник',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Среда',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Четверг',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Пятница',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Суббота',
                    date: "32131",
                    status: "work",
                    active: "activate"
                },
                {
                    name: 'Воскресенье',
                    date: "32131",
                    status: "work",
                    active: "activate"
                }

            ],
            userName: "",
            userMessage: "",
            connection: "",
            windows: [

            ]


        },
        watch: {
            week: function (val) {

                thisVue = this;
                var arr = [0, 1, 2, 3, 4, 5, 6];

                var curr = new Date();
                curr.setDate(curr.getDate() + (7 * (thisVue.week)))

                let bb = []
                // - 7 * thisVue._data.week

                for (let i = 1; i <= 7; i++) {

                    let first = curr.getDate() - curr.getDay() + i


                    let day = new Date(curr.setDate(first))

                    var dd = day.getDate();
                    if (dd.toString().length < 2) {
                        dd = "0" + dd
                    }
                    var mm = day.getMonth() + 1;
                    if (mm.toString().length < 2) {
                        mm = "0" + mm
                    }
                    var yyyy = day.getFullYear();
                    var td = dd + '.' + mm + '.' + yyyy;

                    bb.push(td)




                }

                arr.forEach(function (item, j, arr) {
                    hh = bb[j]

                    thisVue.days[j].active = ""; 

                    axios
                        .get('/GetDay?date=' + hh)
                        .then(function (response) {
                            self.subscribers = response.data;
                            self.isViewReady = true;

                            thisVue.days[j].status = response.data;



                        })
                        .catch(function (error) {
                            alert("ERROR: " + (error.message | error));
                        });


                    thisVue.days[j].date = hh

                    //console.log("ДАта: " + thisVue.days[j].name);

                    //console.log("ДАта: " + thisVue.days[j].date);

                    //console.log("СТАТУС: " + thisVue.days[j].status);
                });
            },
            days: function () {
                thisVue = this;
                //console.log(thisVue)
            }
        },
        methods: {
            //submitCard: function () {
            //    if (this.userName && this.userMessage) {
            //        this.connection.invoke('SendMessage', this.userName, this.userMessage).catch(function (err) {
            //            return console.error(err);
            //        });

            //        this.userName = '';
            //        this.userMessage = '';
            //    }
            //},
            NUE: function (event) {
                var bb = this;
                //let date = event.path[1].children[1].innerText;
                var element = event.path[1];

                //console.log(element.id);
                axios
                    .get('/GetWindows?date=' + bb.$data.days[element.id].date)
                    .then(function (response) {
                        self.subscribers = response.data;
                        self.isViewReady = true;
                        bb.windows = response.data;

                    })
                    .catch(function (error) {
                        alert("ERROR: " + (error.message | error));
                    });
            },

            radioClick: function (event) {
                thisVue = this;
                //console.log(thisVue);



                var d = event.path[2].childNodes;
                var element = event.path[1];
                //console.log(d);

                //console.log(element);
                var arr = [0, 1, 2, 3, 4, 5, 6];

                //console.log(thisVue.$data.days.includes("activate"));

                arr.forEach(function (item, i, arr) {
                    thisVue.days[i].active = "";
                    if (item == element.id) {
                        thisVue.days[i].active = "activate";
                        //thisVue.$data.days[item].status+=" activate"
                    } else {


                    }

                });





            },
            //getWeek: function () {

            //}
        },
        created: function () {
            //this.debouncedGetAnswer = _.debounce(this.getWeek, 500)


            var thisVue = this;
            axios
                .get('/GetWindows?date=' + today())
                .then(function (response) {
                    self.subscribers = response.data;
                    self.isViewReady = true;
                    thisVue.windows = response.data;
                    //console.log(today());
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });

            thisVue.connection = new signalR.HubConnectionBuilder()
                .withUrl('/chatHub', { transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling })
                .configureLogging(signalR.LogLevel.Information)
                .build();

            thisVue.connection.start()


            
            //thisVue.connection.start().catch(function (err) {
            //    return console.error(err.toSting());
            //});

            //var connection = new signalR.HubConnectionBuilder()
            //    .withUrl('/chatHub')
            //    .configureLogging(signalR.LogLevel.Information)
            //    .build();

            //connection.on('ReceiveDate', function (user, message, window) {

            //    console.log("Получение: " + user + " ___ " + message + " ___ " + window)
            //});

            //connection.start()
            //    .then(function () {
            //        console.log('connection started');
            //        connection.invoke('SendDate', today(), today(), today()).catch(function (err) {
            //            return console.error(err);
            //        });
            //    })
            //    .catch(error => {
            //        console.error(error.message);
            //    });
    
        },
        computed: {
            classObject: function () {
                return {
                    active: this.isActive && !this.error,
                    'text-danger': this.error && this.error.type === 'fatal'
                }
            }
        },
        mounted: function () {

            var thisVue = this;
            //axios
            //    .post('/GetWindows?date=' + today())
            //    .then(function (response) {
            //        self.subscribers = response.data;
            //        self.isViewReady = true;
            //        thisVue.windows = response.data;
            //        //console.log(today());
            //    })
            //    .catch(function (error) {
            //        alert("ERROR: " + (error.message | error));
            //    });


            thisVue.connection.on('ReceiveMessage', function (user, leading, message, window, id, edit) {

                const even1 = (element) => element.name == window;
                //const even2 = (element) => element.name == message;
                const even3 = (element) => element.name == id;

                thisVue._data.windows.find(b => b.name == window).hr.find(b => b.id == id).person = user;
                thisVue._data.windows.find(b => b.name == window).hr.find(b => b.id == id).leading = leading;
                thisVue._data.windows.find(b => b.name == window).hr.find(b => b.id == id).edit = edit;
                //console.log("Получение: " + user + "(" + leading + ")" + " ___ " + message + " ___ " + window)
            });




            var arr = [0, 1, 2, 3, 4, 5, 6];

            let curr = new Date
            let week = []
            // - 7 * thisVue._data.week
            for (let i = 1; i <= 7; i++) {
                let first = curr.getDate() - (curr.getDay()) + i
                //console.log(first);
                let day = new Date(curr.setDate(first))

                var dd = day.getDate();
                if (dd.toString().length < 2) {
                    dd = "0" + dd
                }
                var mm = day.getMonth() + 1;
                if (mm.toString().length < 2) {
                    mm = "0" + mm
                }
                var yyyy = day.getFullYear();
                var td = dd + '.' + mm + '.' + yyyy;

                week.push(td)

            }
            var g = 1;
            arr.forEach(function (item, i, arr) {
                hh = week[i]
                thisVue.days[i].active = "";

                //console.log(g++);

                axios
                    .get('/GetDay?date=' + hh)
                    .then(function (response) {
                        self.subscribers = response.data;
                        self.isViewReady = true;
                        thisVue.days[i].status = response.data;
                        if (i == (date.getDay() - 1)) {

                            thisVue.days[i].active = "activate";
                        }
                    })
                    .catch(function (error) {
                        alert("ERROR: " + (error.message | error));
                    });



                thisVue.days[i].date = hh;

            });

        }

    });
});