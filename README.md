# ReBoogiepopT
A program that explores different algorithms / methods for recommendation of media.  
Tailored to anime as a context to develop methods and present recommendations.  
As of now only integrated with anilist.

## Recommendation methods
### Activity Inject
This recommendation method selects users with the latest activity on specified media (called the inject media).  
It then aggregates the selected user's list counting the occurences of repeated media, hence defining a local popularity.  
Results are then presented sorted by global mean score and by local popularity.

Moreover tags can be presented as a way to filter the aggregation down to a selection of interest.  
The filtering uses the concept of *(weakly) coupled tags*.  
A coupled tag is simply a collection of tags of which only one has to be satisfied for the collection to be satisfied.  
It is a way of saying: "I don't care which of these tags is present as long as one of them is."  
**When using a tag make sure that the name corresponds exactly to one used by anilist**, check on relevant anime pages to see the desired tags.  
A coupled tag may be specified by comma seperating the tags that make it up e.g. `Primarily Female Cast, Surreal Comedy, Parody, Slapstick`.  
A single tag is considered a special case of a coupled tag e.g. `Episodic`.

Optionally present your Anilist username to filter out media you've already seen.

Inject media **must** be presented by comma seperated media ids e.g. `10165, 101001, 10495, 21088`.  
When injecting a single media no comma is required e.g. `10165`.  
One finds the media id of an anime in the uri e.g. https://anilist.co/anime/10165/Nichijou/ has media id 10165.

One can also specify the amount of users selected per media (default: 50).  
The more users one selects the longer it takes for the recommendation to complete, which is very noticable.  
This is because making an anilist api request is very slow (about 0.7 - 0.8 seconds in debug).  
For each user that is selected their list has to be queried for as well, therefore the time it takes to complete is linear to the amount of users selected.
(This could possibly be remedied in a future version by querying for multiple users' list in one request.)

Currently for activity inject the selection of users is solely based on the user's list status of the injected media.  
The possible filter conditions are: All, Completed and Not Planning.  
Which respectively mean: accept any user with this inject media as a recent list activity; accept any user with this inject media as a recent completed list activity; accept any user with this inject media as a recent list activity that is not "plan to watch".

An example of properly input settings:  
![alt text](https://i.imgur.com/q0uF8PU.png "Example Settings")

### MetricLift
In an overview MetricLift works as follows:  
1. Let the user prescribe a recommendation pattern.  
2. Lift this recommendation pattern to a different structure.  
3. Use this obtained structure to recommend media.

The recommendation pattern MetricLift uses is that of A -> B, which is taken to mean: "I liked media B because of its resemblance to media A."
In MetricLift this recommendation pattern is called the *base*.
The first step of using this recommendation method is defining the base.
The interface requires the user to specify a base media id 1 and a base media id 2.
The recommendation pattern is then assumed to be 1 -> 2.
Which means that the media specified by base media id 2 is liked because of its resemblance to the media specified by base media id 1.
This covers the first part of the overview.

The second step is to transform this recommendation pattern into a different structure.
Without going into many details, the way MetricLift does that is by defining a *base difference vector* in R^k.
This base difference vector contains the distance between every pair of genres and tags between the two media specified by the base.
Care has been taken in defining the distance functions in that they define a metric topology on the collection of all genres and tags, hence turning the collection of all genres and tags into a metric space.
This metric topology is user dependent and currently has three predefined ways of using user data to help define the distance functions.
One chooses one from the Stat Info Mode option:  
1. Quick. Genre and tag statistics from profile. Has access to the user's top 30 tags sorted by count and the genres.  
2. Sophisticated. Traverses all non plan to watch anime from a user's list to gather genre and tag info.  
3. Favourites. Uses only the anime in the user's favourites to gather genre and tag info.  

As for the distance functions themselves: there are currently two distance functions one can choose from. They fall under the MetricMode option:  
1. Count. Distance based on amount of occurrences of the genre or tag.  
2. Minutes Watched. Distance based on the amount of minutes watched of the genre or tag.

Lastly in this second step there is an option called MetricLiftMode that specifies the interpretation of the pairing of genres and tags when defining difference vectors.  
1. Arrow. View the pairing as an arrow starting from media 1 that goes to media 2. If A is a genre or tag of media 1 and B is a genre or tag of media 2, then the pairs (A, B) and (B, A) are considered different.  
2. Connection. Direction is irrelevant (A, B) and (B, A) are considered the same pairing.

Now for the third step in which this obtained structure will be used to recommend media.
The goal of MetricLift in this step is to find a recommendation pattern C -> D, such that when lifted to a difference vector, it resembles the base difference vector.
However MetricLift requires the user to fill in one half of this recommendation pattern C -> D, namely the C.
This "C" is what's called the *apt media*.
In the interface the user is required to fill in an apt media id that specifies this apt media.
Now when presented with a collection of anime MetricLift will order them based on how well the lifted difference vector of (Apt Media) -> D resembles the base difference vector, where D is an anime in the collection of anime that has been given to be sorted.

The resemblance of the difference vectors is measured by the standard inner product on R^k where k is the dimension of the base difference vector.
Moreover since the dimensions are represented by pairs of genres and tags when taking this inner product these dimensions will be aligned.

The above describes the basic workings of MetricLift.
The media ids mentioned are all anilist anime ids.
Here is an example of properly input settings for MetricLift:  
![alt text](https://i.imgur.com/VZTWWi9.png) "Example Settings MetricLift")

MetricLift is currently usuable in ReBoogiepopT together with Activity Inject, since MetricLift at its core is a way of sorting a collection of anime; whereas Activity Inject at its core is a way of fetching anime which can then be sorted.