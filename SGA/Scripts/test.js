"use strict";
angular.module("niscreenGotWebApp", ["ngAnimate", "ngTouch"]), angular.module("niscreenGotWebApp").config(["$sceProvider", function (a) {
    a.enabled(!1)
} ]), angular.module("niscreenGotWebApp").directive("modal", ["$rootScope", function (a) {
    return {
        restrict: "E",
        templateUrl: "views/templates/informationsidebar.html",
        replace: !0,
        transclude: !0,
        scope: !1,
        link: function (b, c, d) {
            b.isNI ? (angular.element(document.querySelector("#got_scroll")).removeClass("overflowScroll"), angular.element(document.querySelector("#ni_scroll")).addClass("overflowScroll")) : (angular.element(document.querySelector("#ni_scroll")).removeClass("overflowScroll"), angular.element(document.querySelector("#got_scroll")).addClass("overflowScroll")), b.changeMap = function (b) {
                a.isPanorama = !1
            }, b.flipModal = function (d) {
                function e() {
                    a.preventClick = !1, angular.element(c).removeClass("noClick")
                }
                d.stopPropagation(), 0 == a.preventClick && (angular.element(c).addClass("noClick"), a.preventClick = !0, angular.element(c).hasClass("showNi") ? (angular.element(c).removeClass("showNi"), angular.element(c).addClass("showGot"), b.markerselection.isNI = !1) : (angular.element(c).addClass("showNi"), angular.element(c).removeClass("showGot"), b.markerselection.isNI = !0)), setTimeout(function () {
                    b.markerselection.isNI ? (angular.element(document.querySelector("#got_scroll")).removeClass("overflowScroll"), angular.element(document.querySelector("#ni_scroll")).addClass("overflowScroll")) : (angular.element(document.querySelector("#ni_scroll")).removeClass("overflowScroll"), angular.element(document.querySelector("#got_scroll")).addClass("overflowScroll"))
                }, 200), setTimeout(function () {
                    e()
                }, 400)
            }, b.closeModal = function () {
                var d = angular.element(document.getElementById("sidebarWrapper"));
                d.bind("transitionend webkitTransitionEnd", function () {
                    d.unbind("transitionend"), d.unbind("webkitTransitionEnd"), b.markerselection.showImages = !1, angular.element(c).removeClass("showNi"), angular.element(c).removeClass("showGot"), angular.element(c).addClass("showNi"), angular.element(document.querySelector("#got_scroll")).removeClass("overflowScroll"), angular.element(document.querySelector("#ni_scroll")).addClass("overflowScroll")
                }), b.markerselection.showModal = !1, a.selectedLocation = null, a.isPanorama = !1;
                window.innerWidth
            }
        }
    }
} ]).directive("sidebarmodal", ["$rootScope", function (a) {
    return {
        restrict: "E",
        templateUrl: "views/templates/aboutsidebar.html",
        replace: !0,
        transclude: !0,
        scope: !1,
        link: function (a, b, c) {
            a.closeAboutModal = function () {
                a.aboutModal.showAboutModal = !1
            }
        }
    }
} ]).directive("imageonload", function () {
    return {
        restrict: "A",
        link: function (a, b, c) {
            angular.element(b).addClass("hidden"), console.log("imageload"), b.bind("load", function () {
                angular.element(b).removeClass("hidden"), angular.element(b).addClass("loaded")
            })
        }
    }
}).directive("toggleClass", function () {
    return {
        restrict: "A",
        link: function (a, b, c) {
            b.bind("click", function () {
                b.toggleClass(c.toggleClass)
            })
        }
    }
}).directive("mySrc", function () {
    return {
        link: function (a, b, c) { }
    }
}), angular.module("niscreenGotWebApp").service("applicationData", function () {
    var a = {
        westros_points: [{
            id: 1,
            shortname: "Robb Stark's Camp, Oxcross",
            name: "Battle of Oxcross",
            description: "<p>At the behest of the monstrous <strong>Joffrey Lannister</strong>, <strong>Ned Stark</strong> has been beheaded in <strong>King&rsquo;s Landing</strong> and his son, Robb, is declared King in the North. &nbsp;Having amassed a sizeable army and won a trio of battles in the <strong>Riverlands</strong>, Robb wins a decisive victory at <strong>Oxcross</strong>. &nbsp;In the aftermath of the battle Robb meets Talisa, a healer from Volantis, who is tending wounded soldiers on the battlefield. &nbsp;The meeting sets the two on a path that comes to a bloody end at the Red Wedding. </p><p><strong>Audley&rsquo;s Field</strong>, within the <strong>Castle Ward</strong> demesne on the shores of Strangford Lough in <strong>Co. Down</strong>, was used for these pivotal scenes in <strong>Season 2, Episode 4: Garden of Bones</strong>.</p></p>",
            latlong: {
                latitude: 72.16835,
                longitude: -144.42627
            },
            images: ["0101.jpg"],
            season: "2",
            episode: "4"
        }, {
            id: 2,
            shortname: "Lordsport Harbour",
            name: "Pyke, The Iron Islands",
            description: "<p><strong>Theon Greyjoy</strong> has sworn allegiance to Robb Stark and urges him to seek an alliance with Theon's father, <strong>Balon Greyjoy</strong>. Theon reasons that Robb needs a fleet to attack King's Landing and is confident that Balon will listen to him. Having boasted to the ship's captain's daughter of his important standing and how he will be welcomed back home, Theon is sorely disappointed at the lack of reception for his return as he sails into <strong>Lordsport Harbour</strong>. </p><p><strong>Ballintoy Harbour</strong> on the <strong>Causeway Coast </strong>has become synonymous with <strong>Pyke</strong> and the <strong>Iron Islands</strong> and was first used for these scenes in <strong>Season 2 Episode 2: The Night Lands</strong>. The nearby beach was also used for the filming location in the Iron Islands when Theon reaffirms his loyalty to his family by being baptised into the religion of the Drowned God; as well as for Dragonstone in Season 4 Episode 2: The Lion and the Rose, when Melisandre presides over the burning of several of Stannis's bannermen who have refused to cease their open worship of The Seven.</p>",
            latlong: {
                latitude: 74.98093,
                longitude: -146.33691
            },
            images: ["0201.jpg"],
            season: "2",
            episode: "2"
        }, {
            id: 3,
            shortname: "Dothraki Grasslands",
            name: "North of Meereen, Essos",
            description: "<p>Fleeing from the Sons of the Harpy in the fighting pits of <strong>Meereen</strong>, <strong>Daenerys Targaryen</strong> was rescued by her dragon, <strong>Drogon</strong>, and brought to his lair north of the city in the <strong>Dothraki Grasslands </strong>on the continent of <strong>Essos</strong>. Wounded and needing sleep, Drogon ignores Daenerys&rsquo; pleas to take her back to Meereen. While searching for food, she is spotted and surrounded by a Dothraki horde. </p><p><strong>Binevenagh</strong> on the <strong>Antrim Plateau</strong> was the shooting location for these scenes and was first used in the series finale: <strong>Season 5, Episode 10: Mother&rsquo;s Mercy</strong>.</p>",
            latlong: {
                latitude: 62.21676,
                longitude: -19.90723
            },
            images: ["0301.jpg"],
            season: "5",
            episode: "10"
        }, {
            id: 4,
            shortname: "North of Winterfell 1",
            name: "The North",
            description: "<p><strong>Lord Eddard Stark</strong> sentences and executes a deserter of the <strong>Night's Watch</strong> who has tried to warn him about the return of the <strong>White Walkers</strong> but is dismissed as a madman. Penalty for desertion is death. The Stark sons, Robb, Bran and Jon, as well as their ward, <strong>Theon Greyjoy</strong>, all accompany him to the execution where Ned makes a point of telling Bran that the man who passes the sentence should swing the sword, thus taking responsibility for his own decisions.</p><p>Filmed on the rocky escarpments of <strong>Cairncastle in Co. Antrim</strong>, this landscape was first seen in the very first episode of <strong>Season 1: Winter is Coming</strong>.</p>",
            latlong: {
                latitude: 82.50343,
                longitude: -132.03369
            },
            images: ["0401.jpg"],
            season: "1",
            episode: "1"
        }, {
            id: 5,
            shortname: "The Neck",
            name: "On the road to Moat Cailin",
            description: "<p><strong>Sansa Stark</strong>, in the company of <strong>Lord Petyr Baelish</strong> leaves the <strong>Vale</strong> and arrives at <strong>Moat Cailin</strong>, a ruined collection of towers located on the Neck and subject to the rule of <strong>House Bolton</strong>. It is here that Sansa learns they are returning to Winterfell where Littlefinger plans to marry her off to <strong>Ramsay Bolton</strong>, son of <strong>Roose Bolton</strong>, the current Warden of the North. </p><p>The wild landscape of Cairncastle was the filming location for the Neck on the road to Moat Cailin in <strong>Season 5, Episode 3: High Sparrow</strong>.</p>",
            latlong: {
                latitude: 76.80575,
                longitude: -131.00098
            },
            images: ["0501.jpg"],
            season: "5",
            episode: "3"
        }, {
            id: 6,
            shortname: "Winterfell",
            name: "The North",
            description: "<p>Before being burned by <strong>Ramsay Snow</strong> and becoming the seat of <strong>House Bolton</strong>, Winterfell was the seat of <strong>House Stark</strong>. In the first Season we are introduced to key players in the series and through pivotal scenes we get a clear insight into their characters. Bran, Jon, and Robb practise archery in the courtyard with their father, Ned Stark; Arya, bored with her sewing lesson abandons it, grabs a bow and annoys Bran by out-shooting him. </p><p>The <strong>King, Robert Baratheon</strong> and the royal party arrive at Winterfell to make <strong>Ned Stark</strong> the <strong>Hand of the King</strong> and in so doing sets off a chain of events which will have far-reaching consequences for the whole of the Stark family and the fight for the Iron Throne.</p><p><strong>Castle Ward</strong> in <strong>Co. Down</strong> has become synonymous with Winterfell even though it was the filming location only for <strong>Season 1</strong>.</p>",
            latlong: {
                latitude: 81.53446,
                longitude: -132.14354
            },
            images: ["0601.jpg"],
            season: "1",
            episode: "1"
        }, {
            id: 7,
            shortname: "A cove in the Stormlands",
            name: "",
            description: "<p>Following a parley between the brothers, where <strong>Stannis Baratheon</strong> fails in his attempt to get <strong>Renly</strong> to accept him as the true King, Stannis orders <strong>Davos Seaworth</strong> to smuggle <strong>Melisandre</strong> ashore to a cove situated below Renly&rsquo;s camp. There, Davos watches in horror as the red priestess gives birth to the shadow creature which ultimately kills Renly. </p><p><strong>Cushendun Caves</strong> on the <strong>Causeway Coast</strong> was used for this filming location in <strong>Season 2 Episode 4: Garden of Bones</strong>.</p>",
            latlong: {
                latitude: 64.79285,
                longitude: -113.13721
            },
            images: ["0701.jpg"],
            season: "2",
            episode: "4"
        }, {
            id: 8,
            shortname: "Dragonstone",
            name: "",
            description: "<p><strong>Stannis Baratheon</strong>, increasingly under the influence of <strong>Melisandre</strong>, rejects the <strong>Seven Gods of Westeros</strong> and allows her to burn their effigies as an offering to the <strong>Lord of Light</strong>. During the ceremony,<strong> Maester Cressen</strong> is outraged and fearful that Melisandre is leading Stannis into a war that he cannot win; but she proclaims Stannis a champion of the Lord of Light, as he draws a burning sword, Lightbringer, from the fire.</p><p><strong>Downhill Beach</strong> on the <strong>north Atlantic coast</strong> was used for these scenes on <strong>Dragonstone</strong> in <strong>Episode 1 of Season 2: The North Remembers</strong>.</p>",
            latlong: {
                latitude: 71.24436,
                longitude: -109.75342
            },
            images: ["0801.jpg"],
            season: "2",
            episode: "1"
        }, {
            id: 9,
            shortname: "The Kingsroad",
            name: "North of King's Landing",
            description: "<p>Following the death of her father, <strong>Ned Stark</strong>, <strong>Arya</strong> escapes <strong>King&rsquo;s Landing</strong> disguised as a boy. Travelling on the Kingsroad in the back of a cart along with <strong>Yoren</strong>, <strong>Gendry</strong> and <strong>Hot Pie</strong>, all new recruits for the <strong>Night's Watch</strong>, <strong>Arya</strong> starts her long and arduous journey north. </p><p>This was the last scene in <strong>Season 2 Epsiode 1: The North Remembers</strong> and was filmed at the picturesque <strong>Dark Hedges</strong> near Stranocum in <strong>Co. Antrim</strong>.</p>",
            latlong: {
                latitude: 69.71049,
                longitude: -119.61914
            },
            images: ["0901.jpg"],
            season: "2",
            episode: "2"
        }, {
            id: 10,
            shortname: "Runestone",
            name: "Vale of Arryn",
            description: "<p>In the wake of <strong>Joffrey&rsquo;s</strong> assassination, <strong>Sansa Stark</strong>, now thought to be the last surviving Stark and thus the key to the North, is spirited away from King&rsquo;s Landing to the Vale by the scheming <strong>Littlefinger</strong>. <strong>Robin Arryn</strong>, whose mother, <strong>Lysa</strong>, has been pushed to her death through the <strong>Moon Door </strong>by Littlefinger, is taken as a ward by Lord <strong>Yohn Royce</strong> at <strong>Runestone</strong>. Littlefinger and Sansa watch as the hapless Robin practises his swordsmanship. During the training session, Littlefinger receives a raven&hellip;</p><p>For this scene in <strong>Season 5 Episode 1: The Wars to Come</strong>, a location near <strong>Glenariff</strong> in the beautiful <strong>Glens of Antrim</strong> is used for <strong>Runestone</strong>.</p>",
            latlong: {
                latitude: 74.89082,
                longitude: -106.72119
            },
            images: ["1001.jpg"],
            season: "5",
            episode: "1"
        }, {
            id: 11,
            shortname: "The Stormlands",
            name: "",
            description: "<p><strong>Renly Baratheon</strong> and his <strong>Queen</strong>, <strong>Margaery Tyrell</strong>, watch a tourney where her brother <strong>Ser Loras Tyrell</strong> is bested by an unknown knight. Revealed as <strong>Brienne of Tarth</strong>, who has joined with King Renly in the <strong>War of the Five Kings</strong>, she is granted her wish to be named to <strong>Renly&rsquo;s Kingsguard</strong>, despite her gender and lack of knighthood. <strong>Lady Catelyn Stark</strong> arrives in the camp to negotiate an alliance between Renly and her son, Robb Stark, the King in the North. </p><p><strong>Larrybane</strong> on the north coast was the filming location used for<strong> Renly Baratheon&rsquo;s camp</strong> in the <strong>Stormlands</strong> for these scenes in <strong>Season 2 Episode 3: What is Dead May Never Die</strong>.</p>",
            latlong: {
                latitude: 65.2285,
                longitude: -111.93721
            },
            images: ["1101.jpg"],
            season: "2",
            episode: "3"
        }, {
            id: 12,
            shortname: "North of Winterfell 2",
            name: "The North",
            description: "<p><strong>Theon Greyjoy</strong> and the <strong>Ironborn</strong> have attacked Winterfell which is in turn besieged by an army of Northmen led by <strong>Ramsay Bolton</strong>. <strong>Bran Stark</strong>, his younger brother <strong>Rickon</strong>, their direwolves, along with Osha and Hodor have hidden in the Winterfell crypts but managed to escape and, urged by the dying <strong>Maester Luwin</strong>, the group travels north to find Jon Snow at <strong>Castle Black</strong>.</p><p><strong>Leitrim Lodge</strong>, in the foothills of the <strong>Mourne Mountains</strong>, was the filming location for the lands north of Winterfell in <strong>Season 3 Episode 2: Dark Wings, Dark Words</strong>.</p>",
            latlong: {
                latitude: 82.2558,
                longitude: -130.8252
            },
            images: ["1201.jpg"],
            season: "3",
            episode: ""
        }, {
            id: 13,
            shortname: "Renly's camp",
            name: "The Stormlands",
            description: "<p><strong>Renly Baratheon</strong> has been crowned King with the support of the powerful <strong>House Tyrell</strong> and has gathered an army of 100,000 men from across the Reach and the <strong>Stormlands</strong>. His elder brother, <strong>Stannis Baratheon</strong>, who proclaims he is the true heir to the Iron Throne, travels to meet him and demands Renly join with him. The parley breaks down, with Renly vainly asserting he has the larger army. Stannis wheels his horse and rides away as Melisandre warns Renly to look to his sins because 'the night is dark and full of terrors'.</p><p>The wild and windswept cliffs above <strong>Murlough Bay</strong> on the <strong>Antrim coast </strong>were used for these scenes in <strong>Season 2 Episode 4: Garden of Bones</strong>.</p>",
            latlong: {
                latitude: 65.98227,
                longitude: -111.81885
            },
            images: ["1301.jpg"],
            season: "2",
            episode: "3"
        }, {
            id: 14,
            shortname: "Beric Dondarrion's Hideout",
            name: "The Riverlands",
            description: "<p><strong>Arya</strong>, <strong>Gendry</strong> and <strong>Hot Pie</strong> have been trying to reach <strong>Riverrun</strong> when they are captured by the <strong>Brotherhood</strong> without Banners and taken to a local inn to be fed. &nbsp;Just as they are about to leave, <strong>Sandor Clegane</strong> (the Hound) is brought in by other members of the Brotherhood and reveals Arya&rsquo;s true identity. &nbsp;Taken to the leader of the Brotherhood, <strong>Beric Dondarrion</strong>, Arya accuses the Hound of murdering her friend <strong>Mycah</strong>. &nbsp;He is ordered to trial by combat and thinks he has killed Dondarrion, but watches in shock as Beric is resurrected by the Red Priest, <strong>Thoros</strong> of <strong>Myr</strong>.</p><p><strong>Pollnagollum Cave</strong> was used in <strong>Season 3 Episode 4: And Now His Watch is Ended</strong>, as <strong>Hollow Hill</strong> in the <strong>Riverlands</strong>, the hideout of Beric Dondarrion and his Brotherhood without Banners.</p>",
            latlong: {
                latitude: 74.00744,
                longitude: -129.63867
            },
            images: ["1401.jpg"],
            season: "3",
            episode: "7"
        }, {
            id: 15,
            shortname: "Coast of Dorne",
            name: "",
            description: "<p><strong>Cersei Lannister</strong> has despatched her brother, Jaime, to bring his &ldquo;niece&rdquo; <strong>Myrcella</strong> back from Dorne to King&rsquo;s Landing. &nbsp;Having recruited <strong>Ser Bronn</strong> of the <strong>Blackwater</strong> on his mission, the pair arrive on the coast of <strong>Dorne</strong> where they are discovered by Dornish soldiers; a fight ensues and the Dornish are killed . </p><p>Although Jamie and Bronn think they have arrived undetected in Dorne, Ellaria Sand and Oberyn Martell&rsquo;s daughters, the Sand Snakes, have learned of their arrival from the merchant captain who smuggled Jaime and Bronn ashore. Meeting secretly on the beach, Ellaria and the sisters vow vengeance and plan to start a war with the Lannisters. </p><p>The sweeping sands and dunes of <strong>Portstewart Strand</strong> on the <strong>North Atlantic coast </strong>were used for these scenes in <strong>Season 5 Episode 4: Sons of the Harpy</strong>.</p>",
            latlong: {
                latitude: 55.54106,
                longitude: -107.31445
            },
            images: ["1501.jpg"],
            season: "5",
            episode: "4"
        }, {
            id: 16,
            shortname: "Stokeworth",
            name: "The Crownlands",
            description: "<p>Having promised to bring <strong>Myrcella</strong> back to King&rsquo;s Landing from Dorne, <strong>Jamie Lannister </strong>goes to <strong>Stokeworth</strong> to persuade <strong>Ser Bronn</strong> of the Blackwater to go with him. Bronn is strolling with his betrothed, <strong>Lollys</strong>, outside the castle when they are interrupted by Jaime. He reveals that <strong>Cersei Lannister </strong>has arranged for another husband for Lollys and maintains that Bronn will get a much better wife and a much better castle when they return from Dorne with Myrcella.</p><p><strong>Quintin Bay</strong> in<strong> Co. Down</strong> served as the location for Stokeworth in the Crownlands in <strong>Season 5 Episode 2: The House of Black and White</strong>.</p>",
            latlong: {
                latitude: 71.01696,
                longitude: -115.97168
            },
            images: ["1601.jpg"],
            season: "5",
            episode: "4"
        }, {
            id: 17,
            shortname: "Riverrun",
            name: "The Riverlands",
            description: "<p><strong>Hoster Tully</strong> has become old and frail and the responsibility for the rule of <strong>Riverrun</strong> has passed to his son, <strong>Edmure</strong>. Shortly after the <strong>Battle of the Blackwater</strong>, Hoster dies and his brother <strong>Brynden</strong>, known as the Blackfish, Edmure, &nbsp;his daughter Catelyn and grandson Robb gather for his funeral. &nbsp;In keeping with Tully funeral tradition, the body is put &nbsp;adrift in an open boat on the <strong>Red Fork of the Trident River</strong> and set on fire by a flaming arrow. &nbsp;Embarrassingly after several failed attempts to land the flaming arrow, Edmure has to yield to his Uncle Brynden who, of course, manages a perfect shot with his first attempt.</p><p>The <strong>river Quoile</strong> near <strong>Downpatrick in Co. Down</strong> was the perfect location for these scenes in <strong>Season 3 Episode 3: Walk of Punishment</strong>.</p>",
            latlong: {
                latitude: 73.48478,
                longitude: -136.01074
            },
            images: ["1701.jpg"],
            season: "3",
            episode: "3"
        }, {
            id: 18,
            shortname: "Dothraki Sea",
            name: "East of Pentos",
            description: "<p>Having been sold into marriage to <strong>Khal Drogo</strong> by her ruthless brother, <strong>Viserys</strong>,<strong> Daenerys Targaryen</strong> rides with the <strong>Dothraki</strong> Khalasar which has departed <strong>Pentos</strong> and is now heading east to <strong>Vaes Dothrak</strong>. Travelling away from the Free Cities and into the Dothraki Sea, they make camp in the long-grassed plains that the Dothraki call home.</p><p><strong>Shillanavogy Valley</strong> in the shadow of <strong>Slemish Mountain, Co. Antrim</strong> was used for this vast area of grassland in <strong>Essos</strong> in <strong>Season 1 Episode 2: The Kingsroad</strong>.</p>",
            latlong: {
                latitude: 67.187,
                longitude: -44.89014
            },
            images: ["1801.jpg"],
            season: "1",
            episode: "2"
        }, {
            id: 19,
            shortname: "Lands around Winterfell",
            name: "The North",
            description: "<p>Ned Stark, his sons Robb, Bran and Jon and Theon Greyjoy are returning from Will&rsquo;s execution, when they find a dead stag which has gored a female direwolf. She had given birth to pups, all of which huddle by their mother&rsquo;s corpse. The <strong>direwolf</strong> is the <strong>symbol of House Stark</strong> and finding there are as many pups as there are <strong>Stark</strong> children, they take the pups back to <strong>Winterfell</strong> - one each for Robb, Sansa, Arya, Bran and Rickon - and Jon Snow. </p><p><strong>Tollymore Forest</strong> at the foothills of the <strong>Mourne Mountains</strong> was the location used for filming these scenes in <strong>Season 1 Episode 1: Winter is Coming</strong>.</p>",
            latlong: {
                latitude: 81.84647,
                longitude: -133.17891
            },
            images: ["1901.jpg"],
            season: "1",
            episode: "1"
        }, {
            id: 20,
            shortname: "Old Valyrian Canal",
            name: "Essos",
            description: "<p><strong>Tyrion Lannister</strong> has been spirited out of <strong>King&rsquo;s Landing</strong> with the help of <strong>Varys</strong> and has ended up in the Free Cities. Spying him in Pentos, a disgraced <strong>Jorah Mormont</strong> takes Tyrion prisoner and plans to bring him to Daenerys Targaryen. Throwing a bound and gagged Tyrion into a stolen boat, Jorah sets sail across the Summer Sea bound for Meereen. Reaching the ruins of Old Valyria and hoping to pass through undetected, to their amazement they witness <strong>Drogon</strong> flying overhead and at the same time are suddenly attacked by <strong>Stone Men</strong>. During the attack Tyrion falls overboard and is dragged under by a Stone Man; rescued by Jorah, the pair make it safely to a beach where Tyrion regains consciousness.</p><p>These scenes from <strong>Season 5 Episode 5: Kill the Boy</strong> were filmed on <strong>Toome Canal</strong> when it represented the <strong>Old Valyrian Canal</strong> in <strong>Essos</strong>.</p>",
            latlong: {
                latitude: 39.63954,
                longitude: -47.8125
            },
            images: ["2001.jpg"],
            season: "5",
            episode: "5"
        }, {
            id: 21,
            shortname: "Slavers Bay",
            name: "Essos",
            description: "<p><strong>Tyrion Lannister</strong> and <strong>Ser Jorah Mormont</strong>, having been attacked by Stonemen as they sailed on the <strong>Old Valyrian Canal</strong> and lost their boat, have made it ashore and are continuing to <strong>Meereen</strong> on foot. &nbsp;As Tyrion is explaining to Jorah how he came to be in <strong>Volantis</strong>, they are too late trying to hide from a slave ship spotted off shore, as slavers emerge and capture them. &nbsp;Rather than be taken back to Volantis, Tyrion manages to persuade the leader that Jorah is a great fighter and would make him a lot of money in the fighting pits in Meereen; thus securing their onward journey closer to <strong>Daenerys Targaryen</strong>.</p><p><strong>Murlough Bay</strong> on the <strong>Antrim coast</strong> was used for these scenes in <strong>Season 5 Episode 6: Unbowed, Unbent, Unbroken</strong>.</p>",
            latlong: {
                latitude: 52.07951,
                longitude: -38.49609
            },
            images: ["2101.jpg"],
            season: "5",
            episode: ""
        }, {
            id: 22,
            shortname: "Robb Stark's Camp, Riverrun",
            name: "The Riverlands",
            description: "<p><strong>Joffrey</strong> is on the throne and has summoned <strong>Robb Stark</strong> to pay him fealty. Ignoring the King&rsquo;s demand and knowing his father has been arrested in <strong>King&rsquo;s Landing</strong>, Robb calls his bannermen and marches the Stark forces to war against the Lannisters. Camped near <strong>Riverrun</strong>, the Stark army wins the <strong>Battle of the Whispering Wood</strong> and Robb takes Jaime Lannister prisoner. His mother Catelyn arrives at the camp to relay the news that his father, Ned, has been executed at King&rsquo;s Landing. The Houses of the North and the Riverlands rally to Robb and take up the cry, &ldquo;the King in the North!&rdquo; The War of the Five Kings begins.</p><p><strong>Episode 10 in Season 1: Fire and Blood</strong> used <strong>Inch Abbey</strong> as <strong>Robb Stark&rsquo;s camp</strong> at Riverrun.</p>",
            latlong: {
                latitude: 73.23416,
                longitude: -137.06543
            },
            images: ["2201.jpg"],
            season: "1",
            episode: ""
        }],
        ni_points: [{
            id: 1,
            shortname: "Audley's Field",
            name: "Near Strangford, Co. Down",
            description: "<p>Situated in an area of <strong>County Down</strong> known as Lecale, bordered by<strong> Strangford Lough</strong> and the <strong>Irish Sea</strong> on the north, east and south coasts, <strong>Audley's Field</strong> is one of many things 'Audley' in the area. Named after the original Norman family who came over around <strong>1210</strong>, the Audleys lived in the castle up to the mid 17th Century. It is a beautiful, rural spot, with small fields and rolling low hills and easily accessible on foot if you are already visiting <strong>Castle Ward</strong>. By car, travel along the A7 Belfast Road and head towards Inch Abbey Road. Follow this road for approximately 500 yards and Audley's Castle and field are on the left hand side.</p>",
            latlong: {
                latitude: 63.60615,
                longitude: -7.90446
            },
            images: ["0101.jpg"],
            season: "2",
            episode: "4",
            gps: {
                latitude: 54.379874,
                longitude: -5.572045
            }
        }, {
            id: 2,
            shortname: "Ballintoy Harbour",
            name: "Co. Antrim",
            description: "<p><strong>Ballintoy</strong>, from the Irish 'Baile an Tuaigh' meaning 'the northern townland', is a village on the coast of <strong>County Antrim</strong> with the small fishing harbour located at the end of a very small, narrow, steep road down Knocksaughey hill which passes by the entrance to <strong>Larrybane</strong> and <strong>Carrick-a-Rede Rope Bridge</strong>. Known as a 'raised beach', it is located alongside the B15 coast road, 17 miles north-east of Coleraine and five miles west of <strong>Ballycastle</strong>.</p>",
            latlong: {
                latitude: 82.53563,
                longitude: -45.10391
            },
            images: ["0201.jpg"],
            season: "2",
            episode: "2",
            gps: {
                latitude: 55.244124,
                longitude: -6.369378
            }
        }, {
            id: 3,
            shortname: "Binevenagh",
            name: "The Antrim Plateau",
            description: "<p><strong>Binevenagh</strong> or Benevenagh marks the western extent of the <strong>Antrim Plateau</strong> formed around 60 million years ago by molten lava. The plateau and steep cliffs extend for over 6 miles across the peninsula of <strong>Magilligan</strong>, dominating the skyline over the villages of Bellarena, Downhill, Castlerock and Benone beach. The area has been classified as both an <strong>Area of Special Scientific Interest</strong> and as an <strong>Area of Outstanding Natural Beauty</strong>.</p>",
            latlong: {
                latitude: 80.89372,
                longitude: -72.86133
            },
            images: ["0301.jpg"],
            pano: "inchabbey.jpg",
            season: "5",
            episode: "10",
            gps: {
                latitude: 55.121325,
                longitude: -6.920534
            }
        }, {
            id: 4,
            shortname: "Cairncastle",
            name: "Lands above, Co. Antrim",
            description: "<p><strong>Cairncastle</strong> or Carncastle, from the Irish 'carn' meaning 'mound' and the English word 'castle' is a small village and civil parish in <strong>County Antrim</strong> near the town of <strong>Larne</strong> and inland from the village of <strong>Ballygally</strong>. Located on the windswept <strong>Antrim Plateau</strong> on a basalt escarpment above the village is <strong>Knock Dhu</strong>, (from the Irish for 'black hill') a <strong>Bronze Age </strong>promontory <strong>fort</strong> and <strong>settlement</strong>.</p>",
            latlong: {
                latitude: 77.59885,
                longitude: -22.10449
            },
            images: ["0401.jpg"],
            season: "1",
            episode: "1",
            gps: "54.893912, -5.917001",
            gps: {
                latitude: 54.893912,
                longitude: -5.917001
            }
        }, {
            id: 5,
            shortname: "Cairncastle",
            name: "Lands above, Co. Antrim",
            description: "<p><strong>Cairncastle</strong> or Carncastle, from the Irish 'carn' meaning 'mound' and the English word 'castle' is a small village and civil parish in <strong>County Antrim</strong> near the town of <strong>Larne</strong> and inland from the village of <strong>Ballygally</strong>. Located on the windswept <strong>Antrim Plateau</strong> on a basalt escarpment above the village is <strong>Knock Dhu</strong>, (from the Irish for 'black hill') a <strong>Bronze Age </strong>promontory <strong>fort</strong> and <strong>settlement</strong>.</p>",
            latlong: {
                latitude: 77.04927,
                longitude: -23.02734
            },
            images: ["0501.jpg"],
            season: "5",
            episode: "3",
            gps: {
                latitude: 54.893143,
                longitude: -5.908075
            }
        }, {
            id: 6,
            shortname: "Castle Ward",
            name: "Near Strangford, Co. Down",
            description: "<p><strong>Castle Ward</strong>, overlooking <strong>Strangford Lough</strong>, has been home to the Ward family since the <strong>16th century</strong>. The <strong>18th century mansion house</strong> is a unique blend of both classical and gothic architectural styles, resting on a rolling hillside overlooking the lough and surrounded by a beautiful 820-acre walled demesne with gardens and woodland. A National Trust property, Castle Ward is <strong>open year-round</strong>.</p>",
            latlong: {
                latitude: 63.29476,
                longitude: -5.29229
            },
            images: ["0601.jpg"],
            season: "1",
            episode: "1",
            gps: {
                latitude: 54.373103,
                longitude: -5.578586
            }
        }, {
            id: 7,
            shortname: "Cushendun Caves",
            name: "Co. Antrim",
            description: "<p>The village of <strong>Cushendun</strong> stands on an elevated beach at the outflow of the <strong>Glendun</strong> and <strong>Glencorp</strong> valleys and at the mouth of the River Dun. Centuries before this genteel village was built, Cushendun was a safe landing place and harbour for the frequent travellers between Ireland and Scotland. The caves, formed over <strong>400 million years</strong> ago are easily accessible by foot along the coast from the village.</p>",
            latlong: {
                latitude: 81.10681,
                longitude: -28.24502
            },
            images: ["0701.jpg"],
            season: "2",
            episode: "4",
            gps: {
                latitude: 55.12292,
                longitude: -6.036177
            }
        }, {
            id: 8,
            shortname: "Downhill Beach",
            name: "Co. Derry",
            description: "<p>Located in the very north of Northern Ireland, <strong>Downhill Beach</strong> is part of a <strong>7 mile</strong> stretch of sand and surf offering a wealth of activities including water sports and scenic walks. Cars are permitted on this Blue Flag beach throughout the year. Above the beach, the prominent <strong>Mussenden Temple</strong>, one of the most photographed buildings in Northern Ireland offers breath-taking views of the North Coast to the Counties of Derry, Donegal and Antrim.</p>.",
            latlong: {
                latitude: 81.62135,
                longitude: -67.67581
            },
            images: ["0801.jpg"],
            season: "2",
            episode: "1",
            gps: {
                latitude: 55.167874,
                longitude: -6.815766
            }
        }, {
            id: 9,
            shortname: "The Dark Hedges",
            name: "Stranocum, Co. Antrim",
            description: "<p>The <strong>Dark Hedges</strong> is one of the most photographed natural phenomena in Northern Ireland and a popular attraction for tourists from across the world. This beautiful avenue of <strong>beech trees</strong> was planted by the <strong>Stuart</strong> family in the <strong>18th century</strong> and intended to impress visitors as they approached the entrance to <strong>Gracehill House</strong>. </p><p>Centuries later the trees remain a magnificent sight and have become known as the Dark Hedges. The <strong>Grey Lady</strong> (a lost spirit from a long abandoned graveyard) is said to appear at dusk amongst the trees.</p>",
            latlong: {
                latitude: 81.03862,
                longitude: -47.41801
            },
            images: ["0901.jpg"],
            season: "2",
            episode: "1",
            gps: {
                latitude: 55.133906,
                longitude: -6.379876
            }
        }, {
            id: 10,
            shortname: "The Glens of Antrim",
            name: "Near Glenariff, Co. Antrim",
            description: "<p><strong>Glenariff</strong> (from the Irish Gleann Aireamh, meaning 'valley of the ploughman/arable valley') is one of the Glens of Antrim and like all glens in that area, it was shaped during the Ice Age by <strong>giant glaciers</strong>. It is sometimes called the 'Queen of the Glens' and is the biggest and most popular of the <strong>Glens of Antrim</strong>. The village of <strong>Waterfoot</strong> lies on the coast at the foot of the glen while a popular tourist destination is the <strong>Glenariff Forest Park</strong> with its trails through the trees and alongside <strong>picturesque waterfalls</strong>.</p>",
            latlong: {
                latitude: 79.38771,
                longitude: -33.05332
            },
            images: ["1001.jpg"],
            season: "5",
            episode: "1",
            gps: {
                latitude: 55.015631,
                longitude: -6.805882
            }
        }, {
            id: 11,
            shortname: "Larrybane",
            name: "Co. Antrim",
            description: "<p><strong>Larrybane</strong> bay on the <strong>North Antrim Coast</strong>, protected by Sheep Island and a shallow reef, is one of the most sheltered and scenic locations along the <strong>Causeway Coast</strong>. Beneath the limestone cliffs of Larrybane is an unusual sea cave; it was formed shortly after the last ice age when the sea levels were much higher than they are today.</p><p>Its present position above the reach of the destructive power of the sea has allowed some wonderful <strong>karst</strong> features to develop inside, including fine pillars, stalactites and stalagmites.</p>",
            latlong: {
                latitude: 82.33043,
                longitude: -41.0379
            },
            images: ["1101.jpg"],
            season: "2",
            episode: "3",
            gps: {
                latitude: 55.241148,
                longitude: -6.350733
            }
        }, {
            id: 12,
            shortname: "Leitrim Lodge",
            name: "The Mourne Mountains, Co. Down",
            description: "<p><strong>Leitrim Lodge</strong> can be found near <strong>Hilltown</strong> in the western <strong>Mourne Mountains</strong>, a granite mountain range in <strong>County Down</strong> in the south-east of Northern Ireland with staggering panoramic views from points like <strong>Eagle Mountain</strong>, the highest peak in the western Mournes.</p><p>From here you can survey <strong>Slieve Foye</strong> and the <strong>Cooleys</strong> to the west, the distant Sperrins and Belfast Hills to the north, and east to the high Mournes. The Mournes is an area of outstanding natural beauty and has been proposed as the <strong>first national park in Northern Ireland</strong>.</p>",
            latlong: {
                latitude: 53.64464,
                longitude: -31.37701
            },
            images: ["1201.jpg"],
            season: "3",
            episode: "",
            gps: {
                latitude: 54.162948,
                longitude: -6.122508
            }
        }, {
            id: 13,
            shortname: "Above Murlough Bay",
            name: "Co. Antrim",
            description: "<p>Dotted along the famous <strong>Causeway Coast and Glens</strong> route which travels north from Belfast right up to the <strong>Giant&rsquo;s Causeway</strong> and one of the most beautiful driving roads, <strong>Murlough Bay</strong> is a <strong>hidden gem</strong> off the main road, across a cattle grid and down a steep winding path to a coastal path and beach.</p><p>With views of <strong>Rathlin Island </strong>off Northern Ireland&rsquo;s north coast, as well as the <strong>Mull of Kintyre</strong> and the Scottish Islands which lie across the North Channel, Murlough Bay is accessible by car and then by foot.</p>",
            latlong: {
                latitude: 81.91754,
                longitude: -31.8845
            },
            images: ["1301.jpg"],
            season: "2",
            episode: "3",
            gps: {
                latitude: 55.208797,
                longitude: -6.130057
            }
        }, {
            id: 14,
            shortname: "Pollnagollum Cave",
            name: "Marble Arch, Co. Fermanagh",
            description: "<p><strong>Pollnagollum Cave</strong> in <strong>Belmore Forest</strong> is part of the <strong>Marble Arch Caves Global Geopark</strong> in <strong>Co. Fermanagh</strong>. Its name is Irish for 'hole of the doves'. The cave is fed by a waterfall and swells to a torrent during harsh weather. If you fancy catching a glimpse, you can follow the Belmore Forest walk which leads to a viewing point for the cave.</p>",
            latlong: {
                latitude: 61.43877,
                longitude: -117.46598
            },
            images: ["1401.jpg"],
            season: "3",
            episode: "7",
            gps: {
                latitude: 54.3366,
                longitude: -7.8128
            }
        }, {
            id: 15,
            shortname: "Portstewart Strand",
            name: "Co. Derry",
            description: "<p>Between <strong>Portstewart</strong> town and the mouth of the River Bann lies the golden sands and domineering sand dunes of <strong>Portstewart Strand</strong>. This area of natural beauty and of scientific interest is owned and managed by the National Trust. Sweeping along the edge of the North Coast, it is one of Northern Ireland's finest beaches and affords views of <strong>Inishowen</strong> headland and <strong>Mussenden Temple</strong> perched atop the cliffs.</p>",
            latlong: {
                latitude: 81.62917,
                longitude: -63.60513
            },
            images: ["1501.jpg"],
            season: "5",
            episode: "4",
            gps: {
                latitude: 55.16995,
                longitude: -6.734585
            }
        }, {
            id: 16,
            shortname: "Quintin Bay",
            name: "Near Portaferry, Co. Down",
            description: "<p><strong>Quintin Bay</strong> is about 2 miles east of the small town of <strong>Portaferry</strong> on the southern end of the <strong>Ards Peninsula</strong> in <strong>County Down</strong>, near the Narrows at the entrance to <strong>Strangford Lough</strong>. Home to <strong>Quintin Castle</strong>, one of the very few occupied <strong>Anglo-Norman castles</strong> in Ireland, which was built by John de Courcy in <strong>1184</strong>, you can drive down Quintin Bay Road and walk onto the beach.</p>",
            latlong: {
                latitude: 64.81156,
                longitude: -.1417
            },
            images: ["1601.jpg"],
            season: "5",
            episode: "4",
            gps: {
                latitude: 54.377822,
                longitude: -5.488029
            }
        }, {
            id: 17,
            shortname: "Quoile River",
            name: "Near Downpatrick, Co. Down",
            description: "<p><strong>The Quoile River </strong>(from the Irish: An Caol meaning 'the narrow') is a river in County Down, where, in October 1991 during dredging operations, a piece of oak, perhaps the remains of a log-boat, was found. Following dendrochronological dating it was found to have a Neolithic date of <strong>2739 BC</strong>. The Quoile Countryside Centre is a glorious wetland retreat, located just outside <strong>Downpatrick</strong>, which boasts a variety of beautiful and tranquil woodland and riverside walks.</p>",
            latlong: {
                latitude: 62.88522,
                longitude: -11.55
            },
            images: ["1701.jpg"],
            season: "3",
            episode: "3",
            gps: "54.355711, -5.693867",
            gps: {
                latitude: 54.355711,
                longitude: -5.693867
            }
        }, {
            id: 18,
            shortname: "Shillanavoghy Valley",
            name: "Beneath Slemish, Co. Antrim",
            description: "<p>Lying a few miles east of the town of <strong>Ballymena</strong>, this valley lies beneath <strong>Slemish Mountain</strong> in <strong>County Antrim</strong>. &nbsp;The mountain itself is said to be where<strong> St Patrick</strong>, Ireland&rsquo;s patron saint, once tended sheep after being brought to the area by pirates who slaughtered his family. <strong>Slemish</strong> is the plug of an extinct volcano and lies within an <strong>Environmentally Sensitive Area</strong> (ESA). &nbsp;It is an ideal location for bird watchers where large black ravens, buzzards, wheatears and meadow pipits can be seen regularly.</p>",
            latlong: {
                latitude: 77.48809,
                longitude: -33.39845
            },
            images: ["1801.jpg"],
            season: "1",
            episode: "2",
            gps: {
                latitude: 54.8643,
                longitude: -6.0445
            }
        }, {
            id: 19,
            shortname: "Tollymore Forest",
            name: "Foothills of the Mournes, Co. Down",
            description: "<p><strong>Tollymore</strong> in the <strong>Mournes</strong> has four way-marked trails of varying lengths taking the visitor on a tour of the park&rsquo;s most beautiful areas. These trails follow a circular route and are sign posted from the information board in the main car park. <strong>Oak wood</strong> from Tollymore was the preferred material for the interiors of the White Star liners including the <strong>Titanic</strong> which was built in Belfast. Located in the foothills on the Mourne Mountains, Tollymore was the first state forest park in Northern Ireland, established in 1955. Covering an area of <strong>1600 acres</strong>, it boasts myriad walking trails that can be traversed to the gurgling accompaniment of the Shimna River.</p>",
            latlong: {
                latitude: 56.0475,
                longitude: -23.42285
            },
            images: ["1901.jpg"],
            season: "1",
            episode: "1",
            gps: {
                latitude: 54.2189,
                longitude: -5.9512
            }
        }, {
            id: 20,
            shortname: "Toome Canal",
            name: "Co. Antrim",
            description: "<p><strong>Toome</strong>, positioned at the confluence of the <strong>River Bann</strong> and <strong>Lough Neagh</strong> is located approximately twelve miles west of <strong>Antrim</strong> town. The village derives its name from the Irish Tuaim, a 'tumulus' or mound of earth or stones raised over a grave, which can literally be translated as 'burial mound' or 'pagan burial place'. Toome <strong>Canal</strong> is in fact part of the <strong>Lower Bann</strong> river, a canalised waterway with five navigation locks which flows from Lough Neagh at Toome to the Atlantic Ocean at Portstewart.</p>",
            latlong: {
                latitude: 74.93086,
                longitude: -50.42725
            },
            images: ["2001.jpg"],
            season: "5",
            episode: "5",
            gps: {
                latitude: 54.753956,
                longitude: -6.464203
            }
        }, {
            id: 21,
            shortname: "Murlough Bay",
            name: "Co. Antrim",
            description: "<p>Dotted along the famous <strong>Causeway Coast</strong> and <strong>Glens</strong> route which travels north from Belfast right up to the <strong>Giant&rsquo;s Causeway</strong> and one of the most beautiful driving roads, <strong>Murlough Bay</strong> is a hidden gem off the main road, across a cattle grid and down a steep winding path to a coastal path and beach.</p><p>With views of <strong>Rathlin Island</strong> off Northern Ireland&rsquo;s north coast, as well as the Mull of Kintyre and the Scottish Islands which lie across the North Channel, Murlough Bay is accessible by car and then by foot.</p>",
            latlong: {
                latitude: 82.10036,
                longitude: -31.26759
            },
            images: ["2101.jpg"],
            season: "5",
            episode: "",
            gps: {
                latitude: 55.211074,
                longitude: -6.118163
            }
        }, {
            id: 22,
            shortname: "Inch Abbey",
            name: "Co. Down",
            description: "<p>These extensive remains are of a <strong>Cistercian Abbey</strong> founded in <strong>1180</strong>, by <strong>John de Courcy</strong> and set in a beautiful location beside the <strong>River Quoile</strong>, with distant views towards de Courcy's Cathedral town of <strong>Downpatrick</strong>. </p><p>Although not immediately obvious, <strong>Inch Abbey</strong> was erected on an island that is accessed by a causeway, with the River Quoile to the south and marshland to the north. Visible in the distance is <strong>Downpatrick Cathedral</strong>, burial place of Ireland&rsquo;s patron saint.</p>",
            latlong: {
                latitude: 62.63377,
                longitude: -13.79883
            },
            images: ["2201.jpg"],
            season: "1",
            episode: "",
            gps: {
                latitude: 54.336572,
                longitude: -5.72994
            }
        }]
    };
    this.getData = function () {
        return a
    }
}).service("gotoView", ["$state", "toggleLoader", function (a, b) {
    this.loadState = function (a, b) { }
} ]).service("toggleLoader", function () {
    this.showLoader = function () { }, this.hideLoader = function () { }
}), angular.module("niscreenGotWebApp").controller("MainCtrl", ["$scope", "$rootScope", "applicationData", function (a, b, c) {
    function d() {
        var b = 3,
      d = 6;
        e = L.map("niMap", {
            maxZoom: d,
            minZoom: b,
            reuseTiles: !0,
            zoomControl: !1,
            detectRetina: !0,
            fadeAnimation: !0,
            attributionControl: !1,
            tap: !1,
            trackResize: !0,
            tapTolerance: 60,
            bounceAtZoomLimits: !1,
            unloadInvisibleTiles: !1,
            touchZoom: !1,
            maxNativeZoom: d,
            inertia: !0,
            maxBoundsViscosity: 1
        });
        var h = new L.LatLngBounds(e.unproject([0, 6656], d), e.unproject([10240, 0], d));
        e.fitBounds(h), e.setMaxBounds(h), e.addControl(L.control.zoom({
            position: "bottomleft"
        })), L.tileLayer("http://gotnimap.northernirelandscreen.co.uk/images/nitiles/{z}/{x}/{y}.jpg", {
            minZoom: b,
            maxZoom: d,
            bounds: h,
            attribution: "",
            noWrap: !0,
            unloadInvisibleTiles: !1,
            updateWhenIdle: !1,
            bounceAtZoomLimits: !1,
            tms: !0
        }).addTo(e), e.on("dragend", function () {
            e.panInsideBounds(h, {
                animate: !0,
                duration: .5
            })
        }), e.on("move", function () { }), e.on("resize", function () {
            e.panInsideBounds(h, {
                animate: !0,
                duration: .5
            })
        }), e.on("move", function () {
            var a = e.getCenter(),
        b = e._limitCenter(a, e.getZoom(), h);
            !a.equals(b)
        });
        var j = L.icon({
            iconUrl: "http://gotnimap.northernirelandscreen.co.uk/images/icons/img_unseleced_icon.png",
            iconRetinaUrl: "http://gotnimap.northernirelandscreen.co.uk/images/icons/img_unseleced_icon_2x.png",
            shadowUrl: "images/icons/img_flagshadow.png",
            iconSize: [40, 63],
            shadowSize: [68, 46],
            iconAnchor: [20, 63],
            shadowAnchor: [48, 41],
            popupAnchor: [1, -50],
            labelAnchor: [8, -31]
        });
        g = L.markerClusterGroup({
            showCoverageOnHover: !1,
            zoomToBoundsOnClick: !0,
            removeOutsideVisibleBounds: !1,
            maxClusterRadius: 60
        }), g.clearLayers();
        var k = c.getData();
        f = k.westros_points;
        for (var l = k.ni_points, m = k.ni_points, n = [], o = 0; o < m.length; o++) {
            var p = m[o].latlong.latitude,
        q = m[o].latlong.longitude;
            j = L.icon({
                iconUrl: "http://gotnimap.northernirelandscreen.co.uk/images/icons/marker_unselected_season_" + k.ni_points[o].season + ".png",
                iconRetinaUrl: "http://gotnimap.northernirelandscreen.co.uk/images/icons/marker_unselected_season_" + k.ni_points[o].season + ".png",
                shadowUrl: "http://gotnimap.northernirelandscreen.co.uk/images/icons/img_flagshadow.png",
                iconSize: [40, 63],
                shadowSize: [68, 46],
                iconAnchor: [20, 63],
                shadowAnchor: [48, 41],
                popupAnchor: [1, -50],
                labelAnchor: [8, -31]
            });
            var r = L.marker([p, q], {
                icon: j,
                zIndexOffset: 6e3,
                id: m[o].id,
                westros_name: f[o].name,
                westros_shortname: f[o].shortname,
                westros_description: f[o].description,
                westros_latitude: f[o].latlong.latitude,
                westros_longitude: f[o].latlong.longitude,
                westros_images: f[o].images,
                ni_name: l[o].name,
                ni_description: l[o].description,
                ni_latitude: l[o].gps.latitude,
                ni_longitude: l[o].gps.longitude,
                ni_images: l[o].images,
                ni_shortname: k.ni_points[o].shortname,
                season: k.ni_points[o].season
            }).bindLabel(m[o].shortname + '<span class="subLabel">' + f[o].shortname + "</span>", {
                noHide: !0
            }).on("click", i);
            g.addLayer(r), n.push(r)
        }
        e.addLayer(g), setTimeout(function () {
            a.$apply(function () {
                a.hideloader = !0
            })
        }, 1500)
    }
    var e, f, g, h;
    window.innerWidth;
    a.markerselection = {
        id: 1,
        name: "",
        description: "",
        images: ["holding.png"],
        westros_featuredImage: "holding.png",
        ni_featuredImage: "holding.png",
        isNI: !0
    }, a.pointData = null, a.markerselection.showModal = !1, a.isNI = !0, a.filePath = "ni", a.gotMap = !1, a.niMap = !0, b.preventClick = !1, a.showImages = !1, a.hideloader = !1, a.aboutModal = {
        showAboutModal: !1
    }, angular.element(document).ready(function () {
        setTimeout(function () {
            d()
        }, 300)
    }), a.toggleAbout = function () {
        a.aboutModal.showAboutModal === !0 ? a.aboutModal.showAboutModal = !1 : (a.aboutModal.showAboutModal = !0, a.markerselection.showModal = !1)
    };
    var i = function (b) {
        a.$apply(function () {
            a.markerselection.showImages = !1, a.aboutModal.showAboutModal = !1, a.markerselection.isNI = !0
        });
        var c = document.getElementById("ni_scroll");
        c.scrollTop = 0;
        var d = document.getElementById("got_scroll");
        d.scrollTop = 0, j(b, !1)
    },
    j = function (c, d) {
        a.$apply(function () {
            a.markerselection.isNI = !0, a.markerselection = {
                id: c.target.options.id,
                westros_name: c.target.options.westros_name,
                westros_shortname: c.target.options.westros_shortname,
                westros_description: c.target.options.westros_description,
                ni_shortname: c.target.options.ni_shortname,
                ni_name: c.target.options.ni_name,
                ni_description: c.target.options.ni_description,
                ni_latitude: c.target.options.ni_latitude,
                ni_longitude: c.target.options.ni_longitude,
                season: c.target.options.season,
                showImages: !1,
                isNI: !0
            }, a.markerselection.showModal = !0, a.modalVisible = !0
        });
        var e = angular.element(document.getElementById("sidebarWrapper"));
        if (e.bind("transitionend", function () {
            e.unbind("webkitTransitionEnd"), e.unbind("transitionend"), k(c), console.log("transitionend")
        }), e.bind("webkitTransitionEnd", function () {
            e.unbind("webkitTransitionEnd"), e.unbind("transitionEnd"), k(c), console.log("webkitTransitionEnd")
        }), a.markerselection.showModal === !0) {
            var f = angular.element(document.getElementById("gotMainImage"));
            f.removeClass("loaded"), f.addClass("loading");
            var g = angular.element(document.getElementById("niMainImage"));
            g.removeClass("loaded"), g.addClass("loading");
            var h = angular.element(document.getElementById("gotThumbImage"));
            h.removeClass("loaded"), h.addClass("loading");
            var i = angular.element(document.getElementById("niThumbImage"));
            i.removeClass("loaded"), i.addClass("loading"), k(c)
        }
        if (c.target.options.id === b.selectedLocation || c.target.options.id === b.lastLocation) {
            var f = angular.element(document.getElementById("gotMainImage"));
            f.addClass("loaded");
            var g = angular.element(document.getElementById("niMainImage"));
            g.addClass("loaded");
            var h = angular.element(document.getElementById("gotThumbImage"));
            h.addClass("loaded");
            var i = angular.element(document.getElementById("niThumbImage"));
            i.addClass("loaded")
        }
        b.selectedLocation = c.target.options.id, b.lastLocation = c.target.options.id
    },
    k = function (b) {
        a.$apply(function () {
            a.markerselection.showImages = !0, h = b.target.options.westros_images;
            var c = h.length;
            a.markerselection.imagefolder = b.target.options.id, c > 0 && (a.markerselection.westros_featuredImage = h[0], a.markerselection.westros_images = h);
            var d = b.target.options.ni_images,
          e = d.length;
            e > 0 && (a.markerselection.ni_featuredImage = d[0], a.markerselection.ni_images = d)
        })
    }
} ]), angular.module("niscreenGotWebApp").run(["$templateCache", function (a) {
    a.put("views/main.html", '<ng-view style="background:black" animation="no-animation"> <div class="loaderWrapper" ng-class="{hide:hideloader}"> <div class="loader" id="loader-root"><div class="logo"><img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/got_loader.png"></div><div class="spinner"><img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/loader.png"></div></div> </div> <modal info="markerselection"></modal> <sidebarmodal info="aboutModal"></sidebarmodal> <div class="aboutButton"> <button ng-click="toggleAbout()"></button> </div>  <div data-tap-disabled="true" id="gotMapContainer"> <div id="niMap" style="width:80vw; margin:0; padding:0; background: url(\'./Got/images/holdingtile.png\')"></div> </div> </ng-view>'), a.put("views/templates/aboutsidebar.html", '<div class="leaflet-sidebar right aboutSidebar"  id="sidebarWrapper" ng-class="{visible:aboutModal.showAboutModal}"> <div id="sidebar" class="sidebar leaflet-control"> <div class="sideWrapper"> <div class="sides"> <!--start side--> <div class="side front"> <div class="innerScroller" style="overflow-y: scroll"> <!--sidebarHeader START--> <div class="sidebarHeader"> <!--headerImage START--> <div class="headerImage"> <!--btnBack START--> <div class="btnBack"> <a ng-click="closeAboutModal()"> <img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/btn_close.png"> </a> </div> <div class="aboutTitle"> <img class="gotBrand" src="http://gotnimap.northernirelandscreen.co.uk/images/assets/icon_web_brand.png"> <img class="gotBrandSecondary" src="http://gotnimap.northernirelandscreen.co.uk/images/assets/ico_brand_web_secondary.png"> </div> <!--headerImage START--> <img class="loaded" id="aboutMainImage" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/backgrounds/bg_about_head.jpg"> </div> <!--headerImage END--> <div class="sidebarTitle clearfix"> <div class="titleGroup"> <h1>about this map</h1> </div> </div> </div> <!--sidebarHeader END--> <!--sidebarContent START--> <div class="sidebarContent"> <p>Production of <i>Game of Thrones</i> is based in Belfast, with the show filming in various locations across Northern Ireland. This map is an edited web version of our <i>Game of Thrones</i> Filming Locations app which is available to download free on iOS and Android platforms.<br><br> The map introduces you to key scenes from seasons 1-5 of the show and their filming locations across Northern Ireland. We list only publicly accessible locations, which will be updated as new seasons of the show are broadcast. For extra features including 360Â° panoramic photography, as well as directions, please download the app.</p> <p class="copyright"><i>&copy; 2016 Home Box Office, Inc. All rights reserved. GAME OF THRONES&reg; and related images and service marks are the property of <i>Home Box Office, Inc</i>., used under licence. </i></p> <div class="appPromo clearfix"> <h2>AVAILABLE NOW ON<br>IOS &amp; ANDROID</h2> <ul> <li>Beautiful 360Â° VR experiences</li> <li>Explore Westeros and Essos</li> <li>Photography from the show</li> <li>Northern Ireland scenic locations</li> <li>Directions to filming locations</li> </ul> <div class="appStoreLinks clearfix"> <a href="https://geo.itunes.apple.com/gb/app/game-thrones-filming-locations/id1090908717?mt=8" target="_blank"><img src="http://gotnimap.northernirelandscreen.co.uk/images/assets/btn_apple_store.jpg"></a> <a href="https://play.google.com/store/apps/details?id=com.gameofthronesfilminglocations&hl=en_GB" target="_blank"><img src="http://gotnimap.northernirelandscreen.co.uk/images/assets/btn_android_store.jpg"></a> </div> </div> </div> <!--sidebarContent END--> </div> </div> <!--end side--> </div> </div> </div> </div>'), a.put("views/templates/informationsidebar.html", '<div class="leaflet-sidebar right" id="sidebarWrapper" ng-class="{visible:markerselection.showModal,showNi:markerselection.isNI, showGot:!markerselection.isNI}"> <div id="sidebar" class="sidebar leaflet-control"> <div class="sideWrapper"> <div class="sides"> <!--start side--> <div class="side front"> <!--<ion-content id="got_scroll">--> <div class="innerScroller" id="got_scroll"> <!--sidebarHeader START--> <div class="sidebarHeader"> <!--headerImage START--> <div class="headerImage"> <!--btnBack START--> <div class="btnBack"> <a ng-click="closeModal()"> <img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/btn_close.png"> </a> </div> <!--headerImage START--> <img class="loading" imageonload id="gotMainImage" ng-class="{loaded:markerselection.showImages}" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/locations/got/gallery/{{markerselection.imagefolder}}/{{markerselection.westros_featuredImage}}"> </div> <!--headerImage END--> <div class="sidebarTitle clearfix season{{markerselection.season}}"> <div class="markerIcon"> <img ng-src="http://gotnimap.northernirelandscreen.co.uk/images/assets/ico_info_marker_season{{markerselection.season}}.png"> </div> <div class="titleGroup season{{markerselection.season}}"> <h1>{{markerselection.westros_shortname}}</h1> <h2>{{markerselection.westros_name}}</h2> </div> </div> </div> <!--sidebarHeader END--> <!--sidebarContent START--> <div class="sidebarContent" ng-bind-html="markerselection.westros_description"> {{markerselection.westros_description}} </div> <!--sidebarContent END--> </div> <!--sidebarMapLink START--> <div class="sidebarMapLink season{{markerselection.season}}" ng-click="flipModal($event); $event.stopPropagation();"> <div class="previewImage"> <img class="loading" imageonload id="gotThumbImage" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/locations/ni/gallery/{{markerselection.imagefolder}}/{{markerselection.ni_featuredImage}}" width="100"> </div> <div class="previewText"> <p><strong>About the NI location</strong>{{markerselection.ni_shortname}}<span>Season {{markerselection.season}}</span></p> </div> <div class="previewArrow" ng-class="{rotate:niMap}"> <img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/ico_rotate.png"> </div> </div> <!--sidebarMapLink END--> </div> <!--</ion-content>--> <!--end side--> <!--start side--> <div class="side back"> <!--<ion-content id="ni_scroll">--> <div class="innerScroller" id="ni_scroll"> <!--sidebarHeader START--> <div class="sidebarHeader"> <!--headerImage START--> <div class="headerImage"> <!--btnBack START--> <div class="btnBack"> <a ng-click="closeModal()"> <img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/btn_close.png"> </a> </div> <!--btnBack END--> <!--headerImage START--> <img class="loading" imageonload id="niMainImage" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/locations/ni/gallery/{{markerselection.imagefolder}}/{{markerselection.ni_featuredImage}}"> </div> <!--headerImage END--> <div class="sidebarTitle clearfix season{{markerselection.season}}"> <div class="markerIcon"> <img ng-class="{loaded:markerselection.showImages}" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/assets/ico_info_marker_alt_season{{markerselection.season}}.png"> </div> <div class="titleGroup season{{markerselection.season}}"> <h1>{{markerselection.ni_shortname}}</h1> <h2>{{markerselection.ni_name}}</h2> </div> </div> </div> <!--</ion-content>--> <!--sidebarHeader END--> <!--sidebarContent START--> <div class="sidebarContent" ng-bind-html="markerselection.ni_description"> {{markerselection.ni_description}} </div> <!--sidebarContent END--> </div> <!--sidebarMapLink START--> <div class="sidebarMapLink season{{markerselection.season}}" ng-click="flipModal($event);  $event.stopPropagation();"> <div class="previewImage"> <img imageonload class="loading" id="niThumbImage" ng-src="http://gotnimap.northernirelandscreen.co.uk/images/locations/got/gallery/{{markerselection.imagefolder}}/{{markerselection.westros_featuredImage}}" width="100"> </div> <div class="previewText"> <p><strong>About the GoT scene</strong>{{markerselection.westros_shortname}}<span>Season {{markerselection.season}}</span></p> </div> <div class="previewArrow" ng-class="{rotate:gotMap}"> <img src="http://gotnimap.northernirelandscreen.co.uk/images/icons/ico_rotate.png"> </div> </div> <!--sidebarMapLink END--> </div> <!--end side--> </div> </div> </div> </div>'), a.put("views/templates/promomodal.html", '<ion-modal-view class="overlayModal"> <div class="modalContainer"> <div class="btnBack"> <a ng-click="closeModal()"> <img src="http://gotnimap.northernirelandscreen.co.uk/img/icons/btn_close.png"> </a> <div class="contentWrapper"> <div class="gotBrand"> <img src="http://gotnimap.northernirelandscreen.co.uk/img/assets/got_promo.png"> </div> </div> </div> </div> </ion-modal-view>'), a.put("views/templates/slidegallery.html", '<ion-slides options="options" slider="data.slider"> <ion-slide-page> <div class="box blue"><h1>BLUE</h1></div> </ion-slide-page> <ion-slide-page> <div class="box yellow"><h1>YELLOW</h1></div> </ion-slide-page> <ion-slide-page> <div class="box pink"><h1>PINK</h1></div> </ion-slide-page> </ion-slides>')
} ]);