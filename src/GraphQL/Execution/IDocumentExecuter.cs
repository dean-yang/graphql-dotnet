using System;
using System.Threading.Tasks;

namespace GraphQL
{
    /// <summary>
    /// Processes an entire GraphQL request, given an input GraphQL request string. This is intended to
    /// be called by user code to process a query.
    /// <br/><br/>
    /// Typical implementation starts metrics if enabled (see <see cref="Instrumentation.Metrics">Metrics</see>),
    /// relies on <see cref="Execution.IDocumentBuilder">IDocumentBuilder</see> to parse the query,
    /// <see cref="Validation.IDocumentValidator">IDocumentValidator</see> to validate it, and
    /// <see cref="Validation.Complexity.IComplexityAnalyzer">IComplexityAnalyzer</see> to validate the complexity constraints.
    /// Then it executes document listeners if attached, selects an execution strategy, and executes the query
    /// via <see cref="Execution.IExecutionStrategy">IExecutionStrategy</see>. Unhandled exceptions are handled as appropriate for the selected options.
    /// </summary>
    public interface IDocumentExecuter
    {
        /// <summary>
        /// Executes a GraphQL request and returns the result
        /// </summary>
        /// <param name="options">The options of the execution</param>
        Task<ExecutionResult> ExecuteAsync(ExecutionOptions options);

        /// <summary>
        /// Executes a GraphQL request and returns the result
        /// </summary>
        /// <param name="configure">A delegate which configures the execution options</param>
        Task<ExecutionResult> ExecuteAsync(Action<ExecutionOptions> configure);
    }
}
