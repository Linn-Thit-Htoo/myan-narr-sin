import {View, Text, Button} from "react-native";
export default function GetStartedScreen({navigation}){
    return (
        <>
            <View style={{ display: "flex", alignItems: "center", justifyContent: "center", flex:1  }}>
                <Text>Get Started Screen</Text>
                <Button title="GO Home" onPress={()=>navigation.navigate("bottomnavigationbar")} />
            </View>
        </>
    )
}