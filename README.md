# DBGraphXplore - Dependency Scanner

## Overview
**DBGraphXplore-DependencyScanner** is a powerful tool designed to automatically scan databases and construct a **Knowledge Graph** representing the relationships between database objects. This tool facilitates **Database Dependency Analysis**, **Impact Assessment**, and **Visualization** of complex database structures using **Neo4j Graph Database**.

## Key Features
- **Automated Database Scanning**: Extracts schema dependencies from SQL Server databases.
- **Graph Representation**: Constructs a **Knowledge Graph** for database relationships in **Neo4j**.
- **Stored Procedure and Table Dependencies**: Identifies direct and indirect dependencies between database objects.
- **Graph-Based Querying**: Enables Cypher-based querying to explore relationships dynamically.
- **Export & Visualization**: Supports visualization in **Neo4j Browser**, **Graph Data Science (GDS) Library**, and external BI tools.
- **Integration with GenAI**: Leverages **Azure OpenAI** to generate database documentation and provide **Explainable Answers**.

## Installation
### Prerequisites
Ensure the following dependencies are installed before running the project:
- .NET 6.0+
- Neo4j Database (Community/Enterprise)
- SQL Server
- Visual Studio 2022+ (for development)

### Clone the Repository
```sh
git clone https://github.com/PraveenKumar109/DBGraphXplore-DependencyScanner.git
cd DBGraphXplore-DependencyScanner
```

### Build and Run the Application
1. Open the project in **Visual Studio**.
2. Restore dependencies:
    ```sh
    dotnet restore
    ```
3. Build the solution:
    ```sh
    dotnet build
    ```
4. Run the application:
    ```sh
    dotnet run
    ```

## Usage
### 1. Configure Database Connection
Modify the `appsettings.json` file with your **SQL Server** and **Neo4j** credentials.

### 2. Run the Dependency Scanner
Execute the application to:
- Connect to the SQL Server database.
- Extract schema details and dependencies.
- Populate the Neo4j graph database.

### 3. Query the Dependency Graph
Launch Neo4j Browser and execute Cypher queries to analyze dependencies. Example:
```cypher
MATCH (sp:StoredProcedure)-[:DEPENDS_ON]->(tbl:Table)
RETURN sp, tbl
```

## Example Use Cases
- **Impact Analysis**: Find all dependent tables when modifying a stored procedure.
- **Change Management**: Assess the cascading effect of schema modifications.
- **Data Lineage**: Understand data flow between tables and views.
- **Graph-Based Documentation**: Automatically generate structured documentation.
- **BI & Reporting**: Enhance data governance using graph-powered insights.

## Screenshots
### Database Dependency Graph
![Dependency Graph](docs/images/dependency_graph.png)

## Roadmap & Future Enhancements
- **Multi-Database Support**: Extend support for PostgreSQL, MySQL, and Oracle.
- **RAG (Retrieval-Augmented Generation)**: Integrate **GenAI** for **Natural Language Querying** of database insights.
- **Improved Visualization**: Provide interactive dashboards for exploring dependencies.

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new feature branch.
3. Commit and push changes.
4. Open a **Pull Request (PR)** with a description of your changes.

## License
This project is licensed under the [MIT License](LICENSE).

## Contact
For queries or collaborations, reach out via:
- **GitHub Issues**: [Submit an issue](https://github.com/PraveenKumar109/DBGraphXplore-DependencyScanner/issues)
- **Email**: [praveen.kumar4@soprasteria.com](mailto:praveen.kumar4@soprasteria.com)

---
⭐ If you find this project useful, **star** this repository on GitHub to show your support! ⭐
