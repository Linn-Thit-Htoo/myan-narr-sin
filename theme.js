import { DefaultTheme, Provider as PaperProvider } from 'react-native-paper';
  const theme = {
    ...DefaultTheme,
    roundness: 2,
    colors: {
      ...DefaultTheme.colors,
      primary: "#7F8AF0",
      accent: "#C0D7FA",
      danger:'#f30023',
      secondary:'#F4F7FD',
      default:'#fff',
      labelColor:'#717171'
      
    },
  };
  export default theme;