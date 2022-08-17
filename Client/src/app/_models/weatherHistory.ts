export interface WeatherHistory {
    cityId: number
    cityName: string
    weatherId: number
    icon: string
    main: string
    description: string
    max: number
    min: number
    humidity: number
    date: Date
}