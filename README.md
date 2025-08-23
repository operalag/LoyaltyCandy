# LoyaltyCandy 🍬

**A blockchain-powered hypercasual match-3 game that enables brands to deploy gamified loyalty campaigns with automated reward distribution on the Internet Computer Protocol.**


## 🎮 Overview

LoyaltyCandy is a ready-to-deploy hypercasual mobile game designed to boost customer loyalty through engaging gamification. Built on the Internet Computer Protocol (ICP), it provides brands and retailers with a scalable, decentralized solution for loyalty campaigns.

**Proven Success**: Based on our loyalty campaign for a retailer that engaged 5% of the Swiss population, LoyaltyCandy offers a tested approach to customer engagement through gaming.

## ✨ Key Features

### 🎯 For Brands & Retailers
- **Ready-to-Deploy**: Launch loyalty campaigns in weeks, not months
- **Flexible Duration**: Run campaigns for a week, month, or longer periods
- **Multi-brand Support**: Enable cross-brand reward possibilities

### 🎮 For Players
- **Match-3 Gameplay**: Engaging and accessible hypercasual gaming
- **Real Rewards**: Earn points that integrate with brand loyalty systems
- **Secure Wallets**: ICP-based wallet creation and management

### 🔗 Technical Features
- **Smart Contract Rewards**: Automated, programmable reward distribution
- **Internet Identity**: Secure authentication through ICP
- **Decentralized Infrastructure**: Scalable and transparent reward management
- **Real-time Balance Updates**: Instant point distribution and tracking

## 🏗️ Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Unity Game    │────│  ICP Canisters  │────│   Dashboard     │
│   (Frontend)    │    │   (Backend)     │    │  (Analytics)    │
├─────────────────┤    ├─────────────────┤    ├─────────────────┤
│ • Match-3 Game  │    │ • Reward System │    │ • KPI Tracking  │
│ • Wallet UI     │    │ • User Management│    │ • Leaderboards  │
│ • Offline Mode  │    │ • Campaign Logic│    │ • Retention     │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

## 🚀 Getting Started

### Prerequisites

- Unity 2022.3 LTS or higher
- Node.js 18+ 
- dfx (DFINITY Canister SDK)
- Internet Computer wallet

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/operalag/LoyaltyCandy.git
   cd LoyaltyCandy
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Start local ICP network**
   ```bash
   dfx start --background
   ```

4. **Deploy canisters**
   ```bash
   dfx deploy
   ```

5. **Open Unity Project**
   - Launch Unity Hub
   - Open the `LoyaltyCandy-Unity` folder
   - Build and run for your target platform


## 📱 Platform Support

- **Mobile**: iOS, Android
- **Web**: WebGL build for browser play
- **Desktop**: Windows, macOS, Linux (for testing)



### Development Setup

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📋 API Reference

### Core Canisters

- **Reward Canister**: Handles point distribution and balance management
- **User Canister**: Manages player profiles and authentication
- **Campaign Canister**: Controls game rules and campaign parameters
- **Analytics Canister**: Processes and stores game metrics

### Key Methods

```typescript
// Reward distribution
distribute_points(principal: Principal, amount: nat) : async Result<(), Error>

// Get player balance
get_balance(principal: Principal) : async nat

// Create campaign
create_campaign(config: CampaignConfig) : async Result<CampaignId, Error>
```

## 🧪 Testing

Run the test suite:

```bash
# Run all tests
npm test

# Run Unity tests
# Open Unity -> Window -> General -> Test Runner

# Run canister tests
dfx canister call test_canister run_tests
```


## 🏢 Use Cases

- **Retail Chains**: Seasonal promotions and customer engagement
- **Brands**: Product launches and awareness campaigns  
- **Restaurants**: Loyalty programs and repeat visits
- **E-commerce**: Cart abandonment recovery and retention
- **Events**: Conference engagement and networking

## 🔒 Security

- Built on Internet Computer's secure infrastructure
- Internet Identity for user authentication
- Smart contract-based reward distribution
- No personal data stored on-chain
- Regular security audits

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


## 🌟 Acknowledgments

- Internet Computer Protocol team for the robust blockchain infrastructure and support over the year that made this possible in the first place



**Built with ❤️ on the Internet Computer**

*Transforming customer engagement through decentralized gaming*
