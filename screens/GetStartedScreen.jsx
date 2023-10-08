import { View, Text, Image } from "react-native";
import { Button } from "react-native-paper";
import getstarted from "../assets/illustrations/getStartedIcon.jpg";
import theme from "../theme";
import { MaterialIcons } from "@expo/vector-icons";
export default function GetStartedScreen({ navigation }) {
  return (
    <>
      <View
        style={{
          flex: 1,
          alignItems: "center",
          justifyContent: "center",
          backgroundColor: "#fff",
          paddingHorizontal: 20,
          display: "flex",
        }}
      >
        <Image
          source={getstarted}
          style={{
            width: 300,
            height: 300,
            resizeMode: "contain",
            marginBottom: "12%",
          }}
        />
        <Text
          style={{
            textAlign: "center",
            fontSize: 20,
            fontWeight: "bold",
            lineHeight: 45,
            marginBottom: "12%",
          }}
        >
          Unleash Your Imagination: Audiobooks On-the-Go, Anytime, Anywhere.
        </Text>

        <Button
          mode="contained"
          style={{ width: 250 }}
          contentStyle={{ flexDirection: "row-reverse" }}
          icon={() => (
            <MaterialIcons name="double-arrow" size={28} color="#fff" />
          )}
          onPress={()=>navigation.navigate("/login")}
        >
          Get Started
        </Button>
      </View>
    </>
  );
}
