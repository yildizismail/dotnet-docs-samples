﻿// Copyright (c) 2019 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License. You may obtain a copy of
// the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under
// the License.

using Google.Cloud.AutoML.V1;
using System;

namespace GoogleCloudSamples
{
    public class AutoMLGetModel
    {
        // [START automl_get_model]
        /// <summary>
        /// Demonstrates using the AutoML client to get a model by ID.
        /// </summary>
        /// <param name="projectId">GCP Project ID.</param>
        /// <param name="modelId">the Id of the model.</param>
        public static object GetModel(string projectId = "YOUR-PROJECT-ID",
            string modelId = "YOUR-MODEL-ID")
        {
            // Initialize client that will be used to send requests. This client only needs to be created
            // once, and can be reused for multiple requests. After completing all of your requests, call
            // the "close" method on the client to safely clean up any remaining background resources.
            AutoMlClient client = AutoMlClient.Create();

            // Get the full path of the model.
            string modelFullId = ModelName.Format(projectId, "us-central1", modelId);
            Model model = client.GetModel(modelFullId);

            // Display the model information.
            Console.WriteLine($"Model name: {model.Name}");
            // To get the model id, you have to parse it out of the `name` field. As models Ids are
            // required for other methods.
            // Name Format: `projects/{project_id}/locations/{location_id}/models/{model_id}`
            string[] names = model.Name.Split("/");
            string retrievedModelId = names[names.Length - 1];
            Console.WriteLine($"Model id: {retrievedModelId}");
            Console.WriteLine($"Model display name: {model.DisplayName}");
            Console.WriteLine($"Model create time:");
            Console.WriteLine($"\tseconds: { model.CreateTime.Seconds}");
            Console.WriteLine($"\tnanos: {model.CreateTime.Nanos}");
            Console.WriteLine($"Model deployment state: { model.DeploymentState}");

            return 0;
        }

        // [END automl_get_model]

        public static void RegisterCommands(VerbMap<object> verbMap)
        {
            verbMap
                .Add((GetModelOptions opts) =>
                     AutoMLGetModel.GetModel(opts.ProjectID, opts.ModelId));
        }
    }
}
