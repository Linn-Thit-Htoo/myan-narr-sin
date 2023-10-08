import React, {useState,useEffect} from 'react';
import { View, Text, Image, KeyboardAvoidingView } from 'react-native';
import { TextInput, Button } from 'react-native-paper';
import logo from '../../assets/illustrations/logo.png';
import { Fontisto } from '@expo/vector-icons'; 
import theme from '../../theme';

export default function LoginScreen() {
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const [secureTextEntry,setSecureTextEntry] = useState(true);
    const [disabledLoginBtn,setDisabledLoginBtn] = useState(true);
    const btnLogin = () => {
        const postBody = {
            Email: email,
            Password: password
        }
        console.log("postBody: ",postBody);
    }
  return (
    <KeyboardAvoidingView
      style={{ flex:1, backgroundColor:"#fff" }}
      behavior="padding"
      contentContainerStyle={{ height:"100%" }}
    >
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center', backgroundColor: '#fff' }}>
        <Image source={logo} style={{ width: 300, height: 300 }} />
        <Text style={{ fontWeight: '900', textAlign: 'center', fontSize: 20 }}>
          Myan Narr Sin
        </Text>
        <TextInput
          placeholder="Enter your Email"
          style={{ width: '85%', backgroundColor: 'transparent', marginTop: "10%" }}
          mode="flat"
          right={<TextInput.Icon icon="email" color="#000"  />}
          keyboardType="email-address"
          onChangeText={(email)=>[setEmail(email), email==="" || password==="" ? setDisabledLoginBtn(true) : setDisabledLoginBtn(false)]}
        />
        <TextInput
          placeholder="Enter your Password"
          style={{ width: '85%', backgroundColor: 'transparent', marginTop: "10%" }}
          mode="flat"
          right={<TextInput.Icon icon={secureTextEntry ? "eye-off" : "eye"} color="#000" onPress={()=>{setSecureTextEntry(!secureTextEntry)}} />}
          keyboardType="default"
          secureTextEntry={secureTextEntry}
          onChangeText={(password)=>[setPassword(password), password==="" || email==="" ? setDisabledLoginBtn(true) : setDisabledLoginBtn(false)]}
        />
        <Button
          mode="contained"
          style={{ width: 250, marginTop: "10%",}}
          onPress={() => btnLogin()}
          disabled={disabledLoginBtn}
          textColor="#fff"
          buttonColor={theme.colors.primary}
        >
          Login
        </Button>
        <View style={{ flexDirection: 'row', alignItems: 'center', marginTop: 20 }}>
          <View style={{ flex: 1, height: 0.5, backgroundColor: 'black' }} />
          <Text style={{ marginHorizontal: 10 }}>OR</Text>
          <View style={{ flex: 1, height: 0.5, backgroundColor: 'black' }} />
        </View>
        <Button
          mode="contained"
          style={{ width: 250, marginTop: "5%",}}
          onPress={() => {}}
        //   icon="google"
        icon={() => (
            <Fontisto name="google" size={25} color="#000" />
          )}
          textColor="#fff"
          buttonColor={theme.colors.primary}
        >
          Continue with Google
        </Button>
      </View>
    </KeyboardAvoidingView>
  );
}
