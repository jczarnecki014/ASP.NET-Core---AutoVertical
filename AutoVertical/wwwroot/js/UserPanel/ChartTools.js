//Create labels for chart
function generateLabels(period)
    {
        let labels = [];
        let currentMonth = new Date().getMonth()+1
        if(currentMonth < 10)
        {
            currentMonth = `0${currentMonth}`
        }

        switch (period){
            case 'month':
                labels = Array.from({length: 31}, (_, i) => i + 1 + `.${currentMonth}`)
            break

            case 'week':
                let currentDate = new Date();
                let firstDayOfWeek = currentDate.getDate() - (currentDate.getDay()-1) ;
                let lastDayOfWeek = firstDayOfWeek + 6;
                let day = firstDayOfWeek;
                while(day <= lastDayOfWeek){
                    labels.push(day + `.${currentMonth}`)
                    day++;
                }
            break;

            case 'year':
                labels = [
                    'Jan.',
                    'Feb.',
                    'Mar.',
                    'Apr.',
                    'May.',
                    'Jun.',
                    'Jul.',
                    'Aug.',
                    'Sept.',
                    'Oct.',
                    'Nov.',
                    'Dec.'
                    ];
            break;
        }
        return labels;
    }


//Prepare recived data to display in form
function PrepareData(data,period,type){
    let DaysAndTheirStats = []
    switch (period){
        case 'month':
            /// Create array with length from 0 to (current day) where index[0] = 1st and index[currentDay - 1] = curent day
            DaysAndTheirStats = new Date().getUTCDate() 
            ///Fill every day default value with is equal 0 (In default we take that every day in this month haven't views)
            DaysAndTheirStats = [...Array(DaysAndTheirStats).fill(0)]
            /// Change default values (0) on data supplyed from JSON where (element.date).getUTCDate() is specific day in the month where we registere some advert view
            /// day of the date is index in array (so for example index[3] = 3rd.month) and we are filling value in this index datas from Json
            data.forEach(element =>{
                var dateObj = new Date(element.date)
                var day = dateObj.getUTCDate()
                if(type=="viewsStats"){
                    DaysAndTheirStats[day] += element.advertViewsCount
                }
                else if (type == "PhoneNumberDisplaysStatsData"){
                    DaysAndTheirStats[day] += element.phoneNumberDisplays
                }
            })
        break

        case 'week':
            let currentDate = new Date();
            let DayOfWeek = currentDate.getDay() ;
            DaysAndTheirStats = [...Array(DayOfWeek).fill(0)]
            data.forEach(element =>{
                var dateObj = new Date(element.date)
                var day = dateObj.getDay();
                //We need -1 because day equals number day of the week and it start from 1 and index from array starts from 0  
                arryIndex = day - 1;
                if(type=="viewsStats"){
                    DaysAndTheirStats[arryIndex] += element.advertViewsCount
                }
                else if (type == "PhoneNumberDisplaysStatsData"){
                    DaysAndTheirStats[arryIndex] += element.phoneNumberDisplays
                }
            })
        break;

        case 'year':
            let currentMonth = new Date().getMonth(); //Month start from 0
            DaysAndTheirStats = [...Array(currentMonth+1).fill(0)]
            data.forEach(element =>{
                console.log(data)
                var dateObj = new Date(element.date)
                var month = dateObj.getMonth(); // jan = 0 feb=1 march = 2 etc.
                arrayIndex = month;
                if(type=="viewsStats"){
                    DaysAndTheirStats[arrayIndex] += element.advertViewsCount
                }
                else if (type == "PhoneNumberDisplaysStatsData"){
                    DaysAndTheirStats[arrayIndex] += element.phoneNumberDisplays
                }
            })
        break;

    }
    
    return DaysAndTheirStats;
    
}

