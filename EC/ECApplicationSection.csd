<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="822b2578-d70a-41f8-9f7c-5da822ac8680" namespace="EC" xmlSchemaNamespace="urn:EC" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="ApplicatonSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="applicatonSection">
      <attributeProperties>
        <attributeProperty name="Host" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="host" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Port" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="port" isReadOnly="false" defaultValue="10034">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="SyncSend" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="syncSend" isReadOnly="false" defaultValue="false">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="SendThreads" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sendThreads" isReadOnly="false" defaultValue="1">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="ReceiveThreads" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="receiveThreads" isReadOnly="false" defaultValue="1">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="PacketAnalyzer" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="packetAnalyzer" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="MessageCenter" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="messageCenter" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Http" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="http" isReadOnly="false" defaultValue="&quot;http://localhost:10035/&quot;">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="PacketMaxsize" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="packetMaxsize" isReadOnly="false" defaultValue="52428800">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="SendQueue" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sendQueue" isReadOnly="false" defaultValue="true">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="ReceiveQueue" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="receiveQueue" isReadOnly="false" defaultValue="true">
          <type>
            <externalTypeMoniker name="/822b2578-d70a-41f8-9f7c-5da822ac8680/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationSection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>