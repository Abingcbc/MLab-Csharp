<template>
    <el-container>
        <el-aside>
            <div id="palette"></div>
        </el-aside>
        <el-main>
            <div id="canvas"></div>
        </el-main>
        <el-aside style="width: 150px">
            <div id="tools">
                <el-button id="title" type="text"
                           style="font-size: 30px"
                           @click="changeModelName">{{modelName}}</el-button>
                <div class="operation">
                    <el-button id="load" type="info" plain
                               style="margin-top: 20px">Load</el-button>
                    <el-dropdown style="margin-top: 20px;">
                        <el-button id="export" type="info" plain>Export</el-button>
                        <el-dropdown-menu>
                            <el-dropdown-item @click.native="exportPng">.PNG</el-dropdown-item>
                            <el-dropdown-item @click.native="exportJson">.JSON</el-dropdown-item>
                        </el-dropdown-menu>
                    </el-dropdown>
                    <el-button id="save" :loading="saving"
                               @click="save" round
                               style="display: block; margin-top: 20px"
                    >Save</el-button>
                    <el-button id="run" type="primary"
                               icon="el-icon-video-play" circle
                               style="display: block; margin-top: 20px"
                               :loading="running"
                               @click="run"/>
                </div>
            </div>
        </el-aside>
    </el-container>
</template>

<script>
    import go from 'gojs'

    const MAKE = go.GraphObject.make;
    export default {
        name: "Lab",
        data() {
            return {
                modelName: 'Untitled',
                running: false,
                saving: false
            }
        },
        mounted() {
            const context = this;
            context.myDiagram = MAKE(go.Diagram, "canvas", {
                initialContentAlignment: go.Spot.Center,
                initialAutoScale: go.Diagram.UniformToFill,
                layout: MAKE(go.LayeredDigraphLayout,
                    {direction: 0}),
                "undoManager.isEnabled": true,
            });
            context.myDiagram.addDiagramListener("Modified", function () {
                var button = document.getElementById("SaveButton");
                if (button) button.disabled = !this.myDiagram.isModified;
            });

            this.makeTemplate("Table", "forestgreen",
                [],
                [this.makePort("OUT", false)]);

            this.makeTemplate("Join", "mediumorchid",
                [this.makePort("L", true), this.makePort("R", true)],
                [this.makePort("UL", false), this.makePort("ML", false), this.makePort("M", false), this.makePort("MR", false), this.makePort("UR", false)]);

            context.myDiagram.linkTemplate =
                MAKE(go.Link,
                    {
                        routing: go.Link.Orthogonal,
                        corner: 5,
                    },
                    MAKE(go.Shape, {stroke: "gray", strokeWidth: 2}),
                    MAKE(go.Shape, {stroke: "gray", fill: "gray", toArrow: "Standard"}));

            // this.load();

            window.myPalette = MAKE(
                go.Palette, "palette", {
                    nodeTemplateMap: context.myDiagram.nodeTemplateMap,
                    model: new go.GraphLinksModel([
                        {category: 'Join', name: 'Ex'},
                    ])
                }
            );
        },
        methods: {
            load() {
                this.myDiagram.model = go.Model.fromJson("{ \"class\": \"go.GraphLinksModel\",\n" +
                    "  \"nodeCategoryProperty\": \"type\",\n" +
                    "  \"linkFromPortIdProperty\": \"frompid\",\n" +
                    "  \"linkToPortIdProperty\": \"topid\",\n" +
                    "  \"nodeDataArray\": [\n" +
                    "{\"key\":1, \"type\":\"Table\", \"name\":\"Product\"},\n" +
                    "{\"key\":2, \"type\":\"Table\", \"name\":\"Sales\"},\n" +
                    "{\"key\":3, \"type\":\"Table\", \"name\":\"Period\"},\n" +
                    "{\"key\":4, \"type\":\"Table\", \"name\":\"Store\"},\n" +
                    "{\"key\":11, \"type\":\"Join\", \"name\":\"Product, Class\"},\n" +
                    "{\"key\":12, \"type\":\"Join\", \"name\":\"Period\"},\n" +
                    "{\"key\":13, \"type\":\"Join\", \"name\":\"Store\"},\n" +
                    "{\"key\":21, \"type\":\"Project\", \"name\":\"Product, Class\"},\n" +
                    "{\"key\":31, \"type\":\"Filter\", \"name\":\"Boston, Jan2014\"},\n" +
                    "{\"key\":32, \"type\":\"Filter\", \"name\":\"Boston, 2014\"},\n" +
                    "{\"key\":41, \"type\":\"Group\", \"name\":\"Sales\"},\n" +
                    "{\"key\":42, \"type\":\"Group\", \"name\":\"Total Sales\"},\n" +
                    "{\"key\":51, \"type\":\"Join\", \"name\":\"Product Name\"},\n" +
                    "{\"key\":61, \"type\":\"Sort\", \"name\":\"Product Name\"},\n" +
                    "{\"key\":71, \"type\":\"Export\", \"name\":\"File\"}\n" +
                    "  ],\n" +
                    "  \"linkDataArray\": [\n" +
                    "{\"from\":1, \"frompid\":\"OUT\", \"to\":11, \"topid\":\"L\"},\n" +
                    "{\"from\":2, \"frompid\":\"OUT\", \"to\":11, \"topid\":\"R\"},\n" +
                    "{\"from\":3, \"frompid\":\"OUT\", \"to\":12, \"topid\":\"R\"},\n" +
                    "{\"from\":4, \"frompid\":\"OUT\", \"to\":13, \"topid\":\"R\"},\n" +
                    "{\"from\":11, \"frompid\":\"M\", \"to\":12, \"topid\":\"L\"},\n" +
                    "{\"from\":12, \"frompid\":\"M\", \"to\":13, \"topid\":\"L\"},\n" +
                    "{\"from\":13, \"frompid\":\"M\", \"to\":21},\n" +
                    "{\"from\":21, \"frompid\":\"OUT\", \"to\":31},\n" +
                    "{\"from\":21, \"frompid\":\"OUT\", \"to\":32},\n" +
                    "{\"from\":31, \"frompid\":\"OUT\", \"to\":41},\n" +
                    "{\"from\":32, \"frompid\":\"OUT\", \"to\":42},\n" +
                    "{\"from\":41, \"frompid\":\"OUT\", \"to\":51, \"topid\":\"L\"},\n" +
                    "{\"from\":42, \"frompid\":\"OUT\", \"to\":51, \"topid\":\"R\"},\n" +
                    "{\"from\":51, \"frompid\":\"OUT\", \"to\":61},\n" +
                    "{\"from\":61, \"frompid\":\"OUT\", \"to\":71}\n" +
                    "  ]}");
            },
            makePort(name, leftside) {
                var port = MAKE(go.Shape, "Rectangle",
                    {
                        fill: "gray", stroke: null,
                        desiredSize: new go.Size(8, 8),
                        portId: name,  // declare this object to be a "port"
                        toMaxLinks: 1,  // don't allow more than one link into a port
                        cursor: "pointer"  // show a different cursor to indicate potential link point
                    });

                var lab = MAKE(go.TextBlock, name,  // the name of the port
                    {font: "7pt sans-serif"});

                var panel = MAKE(go.Panel, "Horizontal",
                    {margin: new go.Margin(2, 0)});

                // set up the port/panel based on which side of the node it will be on
                if (leftside) {
                    port.toSpot = go.Spot.Left;
                    port.toLinkable = true;
                    lab.margin = new go.Margin(1, 0, 0, 1);
                    panel.alignment = go.Spot.TopLeft;
                    panel.add(port);
                    panel.add(lab);
                } else {
                    port.fromSpot = go.Spot.Right;
                    port.fromLinkable = true;
                    lab.margin = new go.Margin(1, 1, 0, 0);
                    panel.alignment = go.Spot.TopRight;
                    panel.add(lab);
                    panel.add(port);
                }
                return panel;
            },
            makeTemplate(typename, background, inports, outports) {
                var node = MAKE(go.Node, "Spot",
                    MAKE(go.Panel, "Auto",
                        {width: 100, height: 120},
                        MAKE(go.Shape, "Rectangle",
                            {
                                fill: background, stroke: null, strokeWidth: 0,
                                spot1: go.Spot.TopLeft, spot2: go.Spot.BottomRight
                            }),
                        MAKE(go.Panel, "Table",
                            MAKE(go.TextBlock, typename,
                                {
                                    row: 0,
                                    margin: 3,
                                    maxSize: new go.Size(80, NaN),
                                    stroke: "white",
                                    font: "bold 11pt sans-serif"
                                }),
                            MAKE(go.TextBlock,
                                {
                                    row: 2,
                                    margin: 3,
                                    editable: true,
                                    maxSize: new go.Size(80, 40),
                                    stroke: "white",
                                    font: "bold 9pt sans-serif"
                                },
                                new go.Binding("text", "name").makeTwoWay())
                        )
                    ),
                    MAKE(go.Panel, "Vertical",
                        {
                            alignment: go.Spot.Left,
                            alignmentFocus: new go.Spot(0, 0.5, 8, 0)
                        },
                        inports),
                    MAKE(go.Panel, "Vertical",
                        {
                            alignment: go.Spot.Right,
                            alignmentFocus: new go.Spot(1, 0.5, -8, 0)
                        },
                        outports)
                );
                this.myDiagram.nodeTemplateMap.add(typename, node);
            },
            changeModelName() {
                this.$prompt('New Model Name', {
                    confirmButtonText: 'Confirm',
                    cancelButtonText: 'Cancel',
                }).then(({ value }) => {
                    this.$message({
                        type: 'success',
                        message: value
                    });
                    this.modelName = value;
                }).catch(() => {
                });
            },
            run() {
                this.running = true;
            },
            save() {
                this.saving = true;
            },
            exportPng() {
                this.myDiagram.makeImageData({
                    returnType: "blob", callback: (blob) => {
                        const tempElement = document.createElement('a');
                        tempElement.download = this.modelName + '.png';
                        tempElement.style.display = "None";
                        tempElement.href = URL.createObjectURL(blob);
                        document.body.appendChild(tempElement);
                        tempElement.click();
                        document.body.removeChild(tempElement);
                    }
                });
            },
            exportJson() {
                const tempElement = document.createElement('a');
                tempElement.download = this.modelName+'.json';
                tempElement.style.display = "None";
                const blob = new Blob([this.myDiagram.model.toJson()]);
                tempElement.href = URL.createObjectURL(blob);
                document.body.appendChild(tempElement);
                tempElement.click();
                document.body.removeChild(tempElement);
            },
        }
    }
</script>

<style>
    #canvas {
        border-radius: 4px;
        box-shadow: 0 2px 30px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04);
        width: 90%;
        height: 650px;
        display: inline-block;
    }

    #palette {
        border-radius: 4px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04);
        width: 200px;
        height: 650px;
        display: inline-block;
        margin-left: 20px;
        margin-top: 20px;
    }

    #tools {
        float: right;
        margin-right: 30px;
    }
</style>
