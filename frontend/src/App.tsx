import { AppBar, Container, Toolbar, Typography } from '@mui/material'
import DirectionsBusIcon from '@mui/icons-material/DirectionsBus';
import './App.scss'
import VehiclesPage from './pages/VehiclesPage'

function App() {
  return (
    <>
      <AppBar position="static">
        <Container maxWidth="100%">
          <Toolbar disableGutters>
            <DirectionsBusIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} />
            <Typography
              variant="h6"
              noWrap
              sx={{
                mr: 2,
                display: { xs: 'none', md: 'flex' },
                fontFamily: 'monospace',
                fontWeight: 700,
                letterSpacing: '.3rem',
                color: 'inherit',
                textDecoration: 'none',
              }}
            >
              Vehicle Monitoring App
            </Typography>
          </Toolbar>
        </Container>
      </AppBar>
      <VehiclesPage />

    </>
  )
}

export default App
