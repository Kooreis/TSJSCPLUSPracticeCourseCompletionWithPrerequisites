```cpp
#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

bool isCyclicUtil(int v, vector<bool>& visited, vector<bool>& recStack, unordered_map<int, vector<int>>& adj) {
    if(visited[v] == false) {
        visited[v] = true;
        recStack[v] = true;

        for(int i = 0; i < adj[v].size(); ++i) {
            if (!visited[adj[v][i]] && isCyclicUtil(adj[v][i], visited, recStack, adj))
                return true;
            else if (recStack[adj[v][i]])
                return true;
        }
    }
    recStack[v] = false;
    return false;
}

bool isCyclic(int numCourses, vector<pair<int, int>>& prerequisites) {
    unordered_map<int, vector<int>> adj;
    for(int i = 0; i < prerequisites.size(); ++i)
        adj[prerequisites[i].second].push_back(prerequisites[i].first);

    vector<bool> visited(numCourses, false);
    vector<bool> recStack(numCourses, false);

    for(int i = 0; i < numCourses; ++i)
        if (isCyclicUtil(i, visited, recStack, adj))
            return true;

    return false;
}

int main() {
    int numCourses = 2;
    vector<pair<int, int>> prerequisites;
    prerequisites.push_back(make_pair(1, 0));

    if(isCyclic(numCourses, prerequisites))
        cout << "Not possible to finish all courses" << endl;
    else
        cout << "Possible to finish all courses" << endl;

    return 0;
}
```