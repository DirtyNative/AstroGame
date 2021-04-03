import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'stored_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class StoredResource {
  Guid id;
  Guid resourceId;
  Guid resourceSnapshotId;
  double amount;
  double hourlyAmount;

  StoredResource();

  factory StoredResource.fromJson(Map<String, dynamic> json) =>
      _$StoredResourceFromJson(json);
  Map<String, dynamic> toJson() => _$StoredResourceToJson(this);
}
