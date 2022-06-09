<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<br />
<div align="center">
  <a href="https://github.com/rezabashiri/message-dispatcher">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Best-README-Template</h3>

  <p align="center">
    An easy to use template to show how to develop a message dispatcher by .net 6
    <br />
    <a href="https://github.com/rezabashiri/message-dispatcher"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/rezabashiri/message-dispatcher">View Demo</a>
    ·
    <a href="https://github.com/rezabashiri/message-dispatcher/issues">Report Bug</a>
    ·
    <a href="https://github.com/rezabashiri/message-dispatcher/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

There are many separate project in .net comunity to structure of clean code, CQRS, background jobs and message dispatchers but i couldnt find one to include all those topics all together, so I decided to develop a structure to show how to group all those concepts and principles in a single easy to use project

What you will achieve :

- A clean code and Multi-Tiered structure
- Hangfire installed and configured to do back ground jobs
- CQRS pattern enabled by using of MediatR library
- Unit and integration tests
- Configuration and usage of AutoMapper library
- Good example of how to use docker compose to connect two project by docker compose

This project aimed to show basics of some most complicated and high demand concepts of development in these days, and it's down to you to develop it and get of it in your project!

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

- [.net6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

- dotnet
  ```sh
  dotnet build ./"Message Dispatcher.sln"
  ```

### Installation

_Below is how you can run your project via docker compose._

1. Clone the repo
   ```sh
   git clone https://github.com/rezabashiri/message-dispatcher.git
   ```
2. Run docker
   ```sh
   docker compose up -d
   ```
3. [Head to](https://localhost:9001)

<strong>To run integration tests succefully, you need to run project by visual studio through docker compose and then run integration tests (those tests are connecting to API faker project to fetch data</strong>

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [x] Add API faker
- [x] Add CQRS pattern
- [x] Add hangfire
- [ ] Add comments
- [ ] Add authentication and authorization via openiddict as a separate service to project

See the [open issues](https://github.com/rezabashiri/message-dispatcher/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Reza Bashiri - [https://rezabashiri.com/](https://rezabashiri.com/) - rzbashiri@gmail.com

Project Link: [https://github.com/rezabashiri/message-dispatcher](https://github.com/rezabashiri/message-dispatcher)

<p align="right">(<a href="#top">back to top</a>)</p>
