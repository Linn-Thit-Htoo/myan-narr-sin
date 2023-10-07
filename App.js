import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { NavigationContainer, useRoute, useNavigation  } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { MaterialCommunityIcons, Ionicons } from '@expo/vector-icons';
import HomeScreen from './screens/HomeScreen';
import LibraryScreen from './screens/LibraryScreen';
import theme from './theme';
import GetStartedScreen from './screens/GetStartedScreen';
import BookmarkScreen from './screens/BookmarkSceen';
import CategoryScreen from './screens/CategoryScreen';
import ProfileScreen from './screens/ProfileScreen';
function BottomNavigationBar() {
  const route = useRoute();
  const Tab=createBottomTabNavigator();
  const { name } = route;
  return (
    <Tab.Navigator
    initialRouteName="Home"
      screenOptions={({ route }) => ({
        tabBarHideOnKeyboard: true,
        headerShown: false,
        tabBarIcon: ({ focused, color, size }) => {
          let iconName;

          if (route.name === 'Home') {
            iconName = focused ? 'home' : 'home-outline';
          } else if (route.name === 'Library') {
            iconName = focused ? 'book' : "book-outline";
          } else if (route.name === 'Bookmark') {
            iconName = focused ? 'bookmark' : 'bookmark-outline';
          } else if (route.name === 'Profile') {
            iconName = focused ? 'account' : 'account-outline';
          } else if (route.name === 'Categories') {
            iconName = focused ? 'view-dashboard' : 'view-dashboard-outline';          
          }
          const iconComponent = iconName === "book-outline" ? (
            <Ionicons name="library-outline" size={28} color={theme.colors.primary} />
          ) : (
            <Ionicons name="library" size={28} theme={theme.colors.primary} />
          )
          : (
            <MaterialCommunityIcons name={iconName} size={28} color={theme.colors.primary} />
          );
          return (
            <>
              {iconComponent}
            </>
          )
        },
        tabBarActiveTintColor: theme.colors.primary,
        tabBarInactiveTintColor: 'black',
        tabBarStyle: {
          display: name === 'login' || name === 'home' ? 'none' : 'flex',
          height: 65          
        },
        tabBarLabelStyle: {
          marginBottom: 7,
        },
      })}
    >
      <Tab.Screen name="Home" component={HomeScreen} />
      <Tab.Screen name="Library" component={LibraryScreen} />
      <Tab.Screen name="Bookmark" component={BookmarkScreen}/>
      <Tab.Screen name="Categories" component={CategoryScreen} />
      <Tab.Screen name="Profile" component={ProfileScreen} />
      
    </Tab.Navigator>
  );
}
export default function App() {
  const Stack = createNativeStackNavigator();
  return (
   <>
    <NavigationContainer>
      <Stack.Navigator initialRouteName='getstarted' screenOptions={{ headerShown: false }}>
        <Stack.Screen name="bottomnavigationbar" component={BottomNavigationBar}/>
        <Stack.Screen name="getstarted" component={GetStartedScreen} />
      </Stack.Navigator>
    </NavigationContainer>
   </>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
