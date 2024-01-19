open System
open System.IO

type Location =
    {
        City: string
        Mean: double
    }

let locations = [|
    { City = "Abha"; Mean = 18.0 };
    { City = "Abidjan"; Mean = 26.0 };
    { City = "Abéché"; Mean = 29.4 };
    { City = "Accra"; Mean = 26.4 };
    { City = "Addis Ababa"; Mean = 16.0 };
    { City = "Adelaide"; Mean = 17.3 };
    { City = "Aden"; Mean = 29.1 };
    { City = "Ahvaz"; Mean = 25.4 };
    { City = "Albuquerque"; Mean = 14.0 };
    { City = "Alexandra"; Mean = 11.0 };
    { City = "Alexandria"; Mean = 20.0 };
    { City = "Algiers"; Mean = 18.2 };
    { City = "Alice Springs"; Mean = 21.0 };
    { City = "Almaty"; Mean = 10.0 };
    { City = "Amsterdam"; Mean = 10.2 };
    { City = "Anadyr"; Mean = -6.9 };
    { City = "Anchorage"; Mean = 2.8 };
    { City = "Andorra la Vella"; Mean = 9.8 };
    { City = "Ankara"; Mean = 12.0 };
    { City = "Antananarivo"; Mean = 17.9 };
    { City = "Antsiranana"; Mean = 25.2 };
    { City = "Arkhangelsk"; Mean = 1.3 };
    { City = "Ashgabat"; Mean = 17.1 };
    { City = "Asmara"; Mean = 15.6 };
    { City = "Assab"; Mean = 30.5 };
    { City = "Astana"; Mean = 3.5 };
    { City = "Athens"; Mean = 19.2 };
    { City = "Atlanta"; Mean = 17.0 };
    { City = "Auckland"; Mean = 15.2 };
    { City = "Austin"; Mean = 20.7 };
    { City = "Baghdad"; Mean = 22.77 };
    { City = "Baguio"; Mean = 19.5 };
    { City = "Baku"; Mean = 15.1 };
    { City = "Baltimore"; Mean = 13.1 };
    { City = "Bamako"; Mean = 27.8 };
    { City = "Bangkok"; Mean = 28.6 };
    { City = "Bangui"; Mean = 26.0 };
    { City = "Banjul"; Mean = 26.0 };
    { City = "Barcelona"; Mean = 18.2 };
    { City = "Bata"; Mean = 25.1 };
    { City = "Batumi"; Mean = 14.0 };
    { City = "Beijing"; Mean = 12.9 };
    { City = "Beirut"; Mean = 20.9 };
    { City = "Belgrade"; Mean = 12.5 };
    { City = "Belize City"; Mean = 26.7 };
    { City = "Benghazi"; Mean = 19.9 };
    { City = "Bergen"; Mean = 7.7 };
    { City = "Berlin"; Mean = 10.3 };
    { City = "Bilbao"; Mean = 14.7 };
    { City = "Birao"; Mean = 26.5 };
    { City = "Bishkek"; Mean = 11.3 };
    { City = "Bissau"; Mean = 27.0 };
    { City = "Blantyre"; Mean = 22.2 };
    { City = "Bloemfontein"; Mean = 15.6 };
    { City = "Boise"; Mean = 11.4 };
    { City = "Bordeaux"; Mean = 14.2 };
    { City = "Bosaso"; Mean = 30.0 };
    { City = "Boston"; Mean = 10.9 };
    { City = "Bouaké"; Mean = 26.0 };
    { City = "Bratislava"; Mean = 10.5 };
    { City = "Brazzaville"; Mean = 25.0 };
    { City = "Bridgetown"; Mean = 27.0 };
    { City = "Brisbane"; Mean = 21.4 };
    { City = "Brussels"; Mean = 10.5 };
    { City = "Bucharest"; Mean = 10.8 };
    { City = "Budapest"; Mean = 11.3 };
    { City = "Bujumbura"; Mean = 23.8 };
    { City = "Bulawayo"; Mean = 18.9 };
    { City = "Burnie"; Mean = 13.1 };
    { City = "Busan"; Mean = 15.0 };
    { City = "Cabo San Lucas"; Mean = 23.9 };
    { City = "Cairns"; Mean = 25.0 };
    { City = "Cairo"; Mean = 21.4 };
    { City = "Calgary"; Mean = 4.4 };
    { City = "Canberra"; Mean = 13.1 };
    { City = "Cape Town"; Mean = 16.2 };
    { City = "Changsha"; Mean = 17.4 };
    { City = "Charlotte"; Mean = 16.1 };
    { City = "Chiang Mai"; Mean = 25.8 };
    { City = "Chicago"; Mean = 9.8 };
    { City = "Chihuahua"; Mean = 18.6 };
    { City = "Chișinău"; Mean = 10.2 };
    { City = "Chittagong"; Mean = 25.9 };
    { City = "Chongqing"; Mean = 18.6 };
    { City = "Christchurch"; Mean = 12.2 };
    { City = "City of San Marino"; Mean = 11.8 };
    { City = "Colombo"; Mean = 27.4 };
    { City = "Columbus"; Mean = 11.7 };
    { City = "Conakry"; Mean = 26.4 };
    { City = "Copenhagen"; Mean = 9.1 };
    { City = "Cotonou"; Mean = 27.2 };
    { City = "Cracow"; Mean = 9.3 };
    { City = "Da Lat"; Mean = 17.9 };
    { City = "Da Nang"; Mean = 25.8 };
    { City = "Dakar"; Mean = 24.0 };
    { City = "Dallas"; Mean = 19.0 };
    { City = "Damascus"; Mean = 17.0 };
    { City = "Dampier"; Mean = 26.4 };
    { City = "Dar es Salaam"; Mean = 25.8 };
    { City = "Darwin"; Mean = 27.6 };
    { City = "Denpasar"; Mean = 23.7 };
    { City = "Denver"; Mean = 10.4 };
    { City = "Detroit"; Mean = 10.0 };
    { City = "Dhaka"; Mean = 25.9 };
    { City = "Dikson"; Mean = -11.1 };
    { City = "Dili"; Mean = 26.6 };
    { City = "Djibouti"; Mean = 29.9 };
    { City = "Dodoma"; Mean = 22.7 };
    { City = "Dolisie"; Mean = 24.0 };
    { City = "Douala"; Mean = 26.7 };
    { City = "Dubai"; Mean = 26.9 };
    { City = "Dublin"; Mean = 9.8 };
    { City = "Dunedin"; Mean = 11.1 };
    { City = "Durban"; Mean = 20.6 };
    { City = "Dushanbe"; Mean = 14.7 };
    { City = "Edinburgh"; Mean = 9.3 };
    { City = "Edmonton"; Mean = 4.2 };
    { City = "El Paso"; Mean = 18.1 };
    { City = "Entebbe"; Mean = 21.0 };
    { City = "Erbil"; Mean = 19.5 };
    { City = "Erzurum"; Mean = 5.1 };
    { City = "Fairbanks"; Mean = -2.3 };
    { City = "Fianarantsoa"; Mean = 17.9 };
    { City = "Flores,  Petén"; Mean = 26.4 };
    { City = "Frankfurt"; Mean = 10.6 };
    { City = "Fresno"; Mean = 17.9 };
    { City = "Fukuoka"; Mean = 17.0 };
    { City = "Gabès"; Mean = 19.5 };
    { City = "Gaborone"; Mean = 21.0 };
    { City = "Gagnoa"; Mean = 26.0 };
    { City = "Gangtok"; Mean = 15.2 };
    { City = "Garissa"; Mean = 29.3 };
    { City = "Garoua"; Mean = 28.3 };
    { City = "George Town"; Mean = 27.9 };
    { City = "Ghanzi"; Mean = 21.4 };
    { City = "Gjoa Haven"; Mean = -14.4 };
    { City = "Guadalajara"; Mean = 20.9 };
    { City = "Guangzhou"; Mean = 22.4 };
    { City = "Guatemala City"; Mean = 20.4 };
    { City = "Halifax"; Mean = 7.5 };
    { City = "Hamburg"; Mean = 9.7 };
    { City = "Hamilton"; Mean = 13.8 };
    { City = "Hanga Roa"; Mean = 20.5 };
    { City = "Hanoi"; Mean = 23.6 };
    { City = "Harare"; Mean = 18.4 };
    { City = "Harbin"; Mean = 5.0 };
    { City = "Hargeisa"; Mean = 21.7 };
    { City = "Hat Yai"; Mean = 27.0 };
    { City = "Havana"; Mean = 25.2 };
    { City = "Helsinki"; Mean = 5.9 };
    { City = "Heraklion"; Mean = 18.9 };
    { City = "Hiroshima"; Mean = 16.3 };
    { City = "Ho Chi Minh City"; Mean = 27.4 };
    { City = "Hobart"; Mean = 12.7 };
    { City = "Hong Kong"; Mean = 23.3 };
    { City = "Honiara"; Mean = 26.5 };
    { City = "Honolulu"; Mean = 25.4 };
    { City = "Houston"; Mean = 20.8 };
    { City = "Ifrane"; Mean = 11.4 };
    { City = "Indianapolis"; Mean = 11.8 };
    { City = "Iqaluit"; Mean = -9.3 };
    { City = "Irkutsk"; Mean = 1.0 };
    { City = "Istanbul"; Mean = 13.9 };
    { City = "İzmir"; Mean = 17.9 };
    { City = "Jacksonville"; Mean = 20.3 };
    { City = "Jakarta"; Mean = 26.7 };
    { City = "Jayapura"; Mean = 27.0 };
    { City = "Jerusalem"; Mean = 18.3 };
    { City = "Johannesburg"; Mean = 15.5 };
    { City = "Jos"; Mean = 22.8 };
    { City = "Juba"; Mean = 27.8 };
    { City = "Kabul"; Mean = 12.1 };
    { City = "Kampala"; Mean = 20.0 };
    { City = "Kandi"; Mean = 27.7 };
    { City = "Kankan"; Mean = 26.5 };
    { City = "Kano"; Mean = 26.4 };
    { City = "Kansas City"; Mean = 12.5 };
    { City = "Karachi"; Mean = 26.0 };
    { City = "Karonga"; Mean = 24.4 };
    { City = "Kathmandu"; Mean = 18.3 };
    { City = "Khartoum"; Mean = 29.9 };
    { City = "Kingston"; Mean = 27.4 };
    { City = "Kinshasa"; Mean = 25.3 };
    { City = "Kolkata"; Mean = 26.7 };
    { City = "Kuala Lumpur"; Mean = 27.3 };
    { City = "Kumasi"; Mean = 26.0 };
    { City = "Kunming"; Mean = 15.7 };
    { City = "Kuopio"; Mean = 3.4 };
    { City = "Kuwait City"; Mean = 25.7 };
    { City = "Kyiv"; Mean = 8.4 };
    { City = "Kyoto"; Mean = 15.8 };
    { City = "La Ceiba"; Mean = 26.2 };
    { City = "La Paz"; Mean = 23.7 };
    { City = "Lagos"; Mean = 26.8 };
    { City = "Lahore"; Mean = 24.3 };
    { City = "Lake Havasu City"; Mean = 23.7 };
    { City = "Lake Tekapo"; Mean = 8.7 };
    { City = "Las Palmas de Gran Canaria"; Mean = 21.2 };
    { City = "Las Vegas"; Mean = 20.3 };
    { City = "Launceston"; Mean = 13.1 };
    { City = "Lhasa"; Mean = 7.6 };
    { City = "Libreville"; Mean = 25.9 };
    { City = "Lisbon"; Mean = 17.5 };
    { City = "Livingstone"; Mean = 21.8 };
    { City = "Ljubljana"; Mean = 10.9 };
    { City = "Lodwar"; Mean = 29.3 };
    { City = "Lomé"; Mean = 26.9 };
    { City = "London"; Mean = 11.3 };
    { City = "Los Angeles"; Mean = 18.6 };
    { City = "Louisville"; Mean = 13.9 };
    { City = "Luanda"; Mean = 25.8 };
    { City = "Lubumbashi"; Mean = 20.8 };
    { City = "Lusaka"; Mean = 19.9 };
    { City = "Luxembourg City"; Mean = 9.3 };
    { City = "Lviv"; Mean = 7.8 };
    { City = "Lyon"; Mean = 12.5 };
    { City = "Madrid"; Mean = 15.0 };
    { City = "Mahajanga"; Mean = 26.3 };
    { City = "Makassar"; Mean = 26.7 };
    { City = "Makurdi"; Mean = 26.0 };
    { City = "Malabo"; Mean = 26.3 };
    { City = "Malé"; Mean = 28.0 };
    { City = "Managua"; Mean = 27.3 };
    { City = "Manama"; Mean = 26.5 };
    { City = "Mandalay"; Mean = 28.0 };
    { City = "Mango"; Mean = 28.1 };
    { City = "Manila"; Mean = 28.4 };
    { City = "Maputo"; Mean = 22.8 };
    { City = "Marrakesh"; Mean = 19.6 };
    { City = "Marseille"; Mean = 15.8 };
    { City = "Maun"; Mean = 22.4 };
    { City = "Medan"; Mean = 26.5 };
    { City = "Mek'ele"; Mean = 22.7 };
    { City = "Melbourne"; Mean = 15.1 };
    { City = "Memphis"; Mean = 17.2 };
    { City = "Mexicali"; Mean = 23.1 };
    { City = "Mexico City"; Mean = 17.5 };
    { City = "Miami"; Mean = 24.9 };
    { City = "Milan"; Mean = 13.0 };
    { City = "Milwaukee"; Mean = 8.9 };
    { City = "Minneapolis"; Mean = 7.8 };
    { City = "Minsk"; Mean = 6.7 };
    { City = "Mogadishu"; Mean = 27.1 };
    { City = "Mombasa"; Mean = 26.3 };
    { City = "Monaco"; Mean = 16.4 };
    { City = "Moncton"; Mean = 6.1 };
    { City = "Monterrey"; Mean = 22.3 };
    { City = "Montreal"; Mean = 6.8 };
    { City = "Moscow"; Mean = 5.8 };
    { City = "Mumbai"; Mean = 27.1 };
    { City = "Murmansk"; Mean = 0.6 };
    { City = "Muscat"; Mean = 28.0 };
    { City = "Mzuzu"; Mean = 17.7 };
    { City = "N'Djamena"; Mean = 28.3 };
    { City = "Naha"; Mean = 23.1 };
    { City = "Nairobi"; Mean = 17.8 };
    { City = "Nakhon Ratchasima"; Mean = 27.3 };
    { City = "Napier"; Mean = 14.6 };
    { City = "Napoli"; Mean = 15.9 };
    { City = "Nashville"; Mean = 15.4 };
    { City = "Nassau"; Mean = 24.6 };
    { City = "Ndola"; Mean = 20.3 };
    { City = "New Delhi"; Mean = 25.0 };
    { City = "New Orleans"; Mean = 20.7 };
    { City = "New York City"; Mean = 12.9 };
    { City = "Ngaoundéré"; Mean = 22.0 };
    { City = "Niamey"; Mean = 29.3 };
    { City = "Nicosia"; Mean = 19.7 };
    { City = "Niigata"; Mean = 13.9 };
    { City = "Nouadhibou"; Mean = 21.3 };
    { City = "Nouakchott"; Mean = 25.7 };
    { City = "Novosibirsk"; Mean = 1.7 };
    { City = "Nuuk"; Mean = -1.4 };
    { City = "Odesa"; Mean = 10.7 };
    { City = "Odienné"; Mean = 26.0 };
    { City = "Oklahoma City"; Mean = 15.9 };
    { City = "Omaha"; Mean = 10.6 };
    { City = "Oranjestad"; Mean = 28.1 };
    { City = "Oslo"; Mean = 5.7 };
    { City = "Ottawa"; Mean = 6.6 };
    { City = "Ouagadougou"; Mean = 28.3 };
    { City = "Ouahigouya"; Mean = 28.6 };
    { City = "Ouarzazate"; Mean = 18.9 };
    { City = "Oulu"; Mean = 2.7 };
    { City = "Palembang"; Mean = 27.3 };
    { City = "Palermo"; Mean = 18.5 };
    { City = "Palm Springs"; Mean = 24.5 };
    { City = "Palmerston North"; Mean = 13.2 };
    { City = "Panama City"; Mean = 28.0 };
    { City = "Parakou"; Mean = 26.8 };
    { City = "Paris"; Mean = 12.3 };
    { City = "Perth"; Mean = 18.7 };
    { City = "Petropavlovsk-Kamchatsky"; Mean = 1.9 };
    { City = "Philadelphia"; Mean = 13.2 };
    { City = "Phnom Penh"; Mean = 28.3 };
    { City = "Phoenix"; Mean = 23.9 };
    { City = "Pittsburgh"; Mean = 10.8 };
    { City = "Podgorica"; Mean = 15.3 };
    { City = "Pointe-Noire"; Mean = 26.1 };
    { City = "Pontianak"; Mean = 27.7 };
    { City = "Port Moresby"; Mean = 26.9 };
    { City = "Port Sudan"; Mean = 28.4 };
    { City = "Port Vila"; Mean = 24.3 };
    { City = "Port-Gentil"; Mean = 26.0 };
    { City = "Portland {OR}"; Mean = 12.4 };
    { City = "Porto"; Mean = 15.7 };
    { City = "Prague"; Mean = 8.4 };
    { City = "Praia"; Mean = 24.4 };
    { City = "Pretoria"; Mean = 18.2 };
    { City = "Pyongyang"; Mean = 10.8 };
    { City = "Rabat"; Mean = 17.2 };
    { City = "Rangpur"; Mean = 24.4 };
    { City = "Reggane"; Mean = 28.3 };
    { City = "Reykjavík"; Mean = 4.3 };
    { City = "Riga"; Mean = 6.2 };
    { City = "Riyadh"; Mean = 26.0 };
    { City = "Rome"; Mean = 15.2 };
    { City = "Roseau"; Mean = 26.2 };
    { City = "Rostov-on-Don"; Mean = 9.9 };
    { City = "Sacramento"; Mean = 16.3 };
    { City = "Saint Petersburg"; Mean = 5.8 };
    { City = "Saint-Pierre"; Mean = 5.7 };
    { City = "Salt Lake City"; Mean = 11.6 };
    { City = "San Antonio"; Mean = 20.8 };
    { City = "San Diego"; Mean = 17.8 };
    { City = "San Francisco"; Mean = 14.6 };
    { City = "San Jose"; Mean = 16.4 };
    { City = "San José"; Mean = 22.6 };
    { City = "San Juan"; Mean = 27.2 };
    { City = "San Salvador"; Mean = 23.1 };
    { City = "Sana'a"; Mean = 20.0 };
    { City = "Santo Domingo"; Mean = 25.9 };
    { City = "Sapporo"; Mean = 8.9 };
    { City = "Sarajevo"; Mean = 10.1 };
    { City = "Saskatoon"; Mean = 3.3 };
    { City = "Seattle"; Mean = 11.3 };
    { City = "Ségou"; Mean = 28.0 };
    { City = "Seoul"; Mean = 12.5 };
    { City = "Seville"; Mean = 19.2 };
    { City = "Shanghai"; Mean = 16.7 };
    { City = "Singapore"; Mean = 27.0 };
    { City = "Skopje"; Mean = 12.4 };
    { City = "Sochi"; Mean = 14.2 };
    { City = "Sofia"; Mean = 10.6 };
    { City = "Sokoto"; Mean = 28.0 };
    { City = "Split"; Mean = 16.1 };
    { City = "St. John's"; Mean = 5.0 };
    { City = "St. Louis"; Mean = 13.9 };
    { City = "Stockholm"; Mean = 6.6 };
    { City = "Surabaya"; Mean = 27.1 };
    { City = "Suva"; Mean = 25.6 };
    { City = "Suwałki"; Mean = 7.2 };
    { City = "Sydney"; Mean = 17.7 };
    { City = "Tabora"; Mean = 23.0 };
    { City = "Tabriz"; Mean = 12.6 };
    { City = "Taipei"; Mean = 23.0 };
    { City = "Tallinn"; Mean = 6.4 };
    { City = "Tamale"; Mean = 27.9 };
    { City = "Tamanrasset"; Mean = 21.7 };
    { City = "Tampa"; Mean = 22.9 };
    { City = "Tashkent"; Mean = 14.8 };
    { City = "Tauranga"; Mean = 14.8 };
    { City = "Tbilisi"; Mean = 12.9 };
    { City = "Tegucigalpa"; Mean = 21.7 };
    { City = "Tehran"; Mean = 17.0 };
    { City = "Tel Aviv"; Mean = 20.0 };
    { City = "Thessaloniki"; Mean = 16.0 };
    { City = "Thiès"; Mean = 24.0 };
    { City = "Tijuana"; Mean = 17.8 };
    { City = "Timbuktu"; Mean = 28.0 };
    { City = "Tirana"; Mean = 15.2 };
    { City = "Toamasina"; Mean = 23.4 };
    { City = "Tokyo"; Mean = 15.4 };
    { City = "Toliara"; Mean = 24.1 };
    { City = "Toluca"; Mean = 12.4 };
    { City = "Toronto"; Mean = 9.4 };
    { City = "Tripoli"; Mean = 20.0 };
    { City = "Tromsø"; Mean = 2.9 };
    { City = "Tucson"; Mean = 20.9 };
    { City = "Tunis"; Mean = 18.4 };
    { City = "Ulaanbaatar"; Mean = -0.4 };
    { City = "Upington"; Mean = 20.4 };
    { City = "Ürümqi"; Mean = 7.4 };
    { City = "Vaduz"; Mean = 10.1 };
    { City = "Valencia"; Mean = 18.3 };
    { City = "Valletta"; Mean = 18.8 };
    { City = "Vancouver"; Mean = 10.4 };
    { City = "Veracruz"; Mean = 25.4 };
    { City = "Vienna"; Mean = 10.4 };
    { City = "Vientiane"; Mean = 25.9 };
    { City = "Villahermosa"; Mean = 27.1 };
    { City = "Vilnius"; Mean = 6.0 };
    { City = "Virginia Beach"; Mean = 15.8 };
    { City = "Vladivostok"; Mean = 4.9 };
    { City = "Warsaw"; Mean = 8.5 };
    { City = "Washington, D.C."; Mean = 14.6 };
    { City = "Wau"; Mean = 27.8 };
    { City = "Wellington"; Mean = 12.9 };
    { City = "Whitehorse"; Mean = -0.1 };
    { City = "Wichita"; Mean = 13.9 };
    { City = "Willemstad"; Mean = 28.0 };
    { City = "Winnipeg"; Mean = 3.0 };
    { City = "Wrocław"; Mean = 9.6 };
    { City = "Xi'an"; Mean = 14.1 };
    { City = "Yakutsk"; Mean = -8.8 };
    { City = "Yangon"; Mean = 27.5 };
    { City = "Yaoundé"; Mean = 23.8 };
    { City = "Yellowknife"; Mean = -4.3 };
    { City = "Yerevan"; Mean = 12.4 };
    { City = "Yinchuan"; Mean = 9.0 };
    { City = "Zagreb"; Mean = 10.7 };
    { City = "Zanzibar City"; Mean = 26.0 };
    { City = "Zürich"; Mean = 9.3 };
|]

let rng = new Random()

// Adapted from https://stackoverflow.com/a/218600/67392
let gausianRand mean stdDev =
    let u1 = 1.0 - rng.NextDouble ()
    let u2 = 1.0 - rng.NextDouble ()
    // Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    let randNormal = sqrt (-2.0 * log u1) * sin (2.0 * Math.PI * u2)
    mean + stdDev * randNormal

let getRandomLocation () =
    let c = Array.length locations
    let r = rng.Next(c)
    locations[r]

let buildFile filename count =
    use strm = File.OpenWrite(filename)
    use wrtr = new StreamWriter(strm)
    for idx = 1 to count do
        let c = getRandomLocation ()
        let reading = gausianRand (c.Mean) 10.0
        wrtr.WriteLine($"{c.City};{reading:``0.0``}")
    ()

[<EntryPoint>]
let main(args) =
    printfn $"iBRC CreateData"
    printfn $"Working folder: {Environment.CurrentDirectory}"
    printfn ""

    if args.Length <> 2 then
        eprintfn "Invalid command line"
        eprintfn "Usage:"
        eprintfn "  CreateData <filename> <count>"
        1
    else
        let filename = args[0]
        let count = Int32.Parse(args[1])
        printfn $"Creating {count} rows into \"{filename}\""
        buildFile filename count
        0
