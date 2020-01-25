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
This is because making an anilist api request is very slow (about 0.7 - 0.8 seconds).
For each user that is selected their list has to be queried for as well, therefore the time it takes to complete is linear to the amount of users selected.
(This could possibly be remedied in a future version by querying for multiple users' list in one request.)

Currently for activity inject the selection of users is solely based on the user's list status of the injected media.
The possible filter conditions are: All, Completed and Not Planning.
Which respectively mean: accept any user with this inject media as a recent list activity; accept any user with this inject media as a recent completed list activity; accept any user with this inject media as a recent list activity that is not "plan to watch".

An example of properly input settings:
![alt text](https://i.imgur.com/q0uF8PU.png "Example Settings")